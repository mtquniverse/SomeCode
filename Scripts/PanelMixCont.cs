using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MarcosQuijada.Chemibot {
public class PanelMixCont : MonoBehaviour {

    [SerializeField] InventarySlot[] inventarySlot;
    [SerializeField] Image imageAlone;
    [SerializeField] Image[] imageSubs;

    [SerializeField] TMP_Text subsTxt;
    SubstanceName[] subsSelected = {SubstanceName.None, SubstanceName.None, SubstanceName.None, SubstanceName.None}; 

    bool addingHeat = false; 
    bool addingCold = false;
    [SerializeField] GameObject imgHeat, imgCold;
    [SerializeField] Toggle toggleHeat, toggleCold;
    [SerializeField] CombineRecipes combineRecipes;
    TweenEffects tweener;
    string textMsg;
    bool procesing = false;

    private IEnumerator fillTextCoroutine;


    void Start() {
        MtEvents.onUpdateSubstancesSelected += OnUpdateSubstancesSelected;
        MtEvents.onRestartMission += OnRestartMission;   
        MtEvents.onShowMessage += OnShowMessage;
        MtEvents.onChangeStatusGame += Reset;
        tweener = this.GetComponent<TweenEffects>();
    }

    private void OnDestroy() {
        MtEvents.onUpdateSubstancesSelected -= OnUpdateSubstancesSelected;
        MtEvents.onShowMessage -= OnShowMessage;
        MtEvents.onRestartMission -= OnRestartMission;   
        MtEvents.onChangeStatusGame -= Reset;
    }

    void OnRestartMission() {
        tweener.Hide();
    }

    void OnShowMessage(string lineTalk, bool talkFast) {
        if (Game.ins.statusGame == StatusGame.Mixing) FillText(Game.ins.GetText(lineTalk,true));
    }



    private void OnUpdateSubstancesSelected(bool isAResult) {
        if (Game.ins.statusGame != StatusGame.Mixing) return; 
        if (isAResult) textMsg = Game.ins.GetText("YouGot");
        else textMsg = Game.ins.GetText("Mixing");
        for (int i = 0; i< subsSelected.Length; i++) {
            subsSelected[i] = SubstanceName.None;
        }
        int x = 0;
        subsTxt.text = "";
        imageAlone.sprite = Game.ins.substances.Sprite(SubstanceName.None);    
        for (int i = 0; i < 4; i++) {
            subsSelected[i] = SubstanceName.None;
            imageSubs[i].sprite =  Game.ins.substances.Sprite(SubstanceName.None);       
        }
        for (int i = 0; i < inventarySlot.Length; i++) {
            if (inventarySlot[i].IsSelected()) {
                subsSelected[x] = inventarySlot[i].substanceName;
                imageSubs[x].sprite =  Game.ins.substances.Sprite(subsSelected[x]);
                if (x == 0) {
                    imageAlone.sprite = Game.ins.substances.Sprite(subsSelected[x]);
                    textMsg =  textMsg + Game.ins.substances.Name(subsSelected[x]);  
                } else {
                    textMsg =  textMsg + ", " + Game.ins.substances.Name(subsSelected[x]);        
                }
                x++;
                if (x > 3) {
                    break;
                }
            }
        }
        textMsg =  textMsg + ".";
        FillText(textMsg);
        if (x <= 1) {
            if (!imageAlone.gameObject.activeSelf) imageAlone.gameObject.SetActive(true);
            foreach (Image go in imageSubs) if (go.gameObject.activeSelf) go.gameObject.SetActive(false);
        } else {
            if (imageAlone.gameObject.activeSelf) imageAlone.gameObject.SetActive(false);    
            foreach (Image go in imageSubs) if (!go.gameObject.activeSelf) go.gameObject.SetActive(true);            
        }
    }


    public void FillText(string msg) {
        if (fillTextCoroutine != null) StopCoroutine(fillTextCoroutine);
        fillTextCoroutine = FillingTextCor(msg);
        StartCoroutine(fillTextCoroutine);
    }
    IEnumerator FillingTextCor(string msg) {
        Game.ins.msgCompleted = false;
        subsTxt.text = "";
        //print("msg to show: " + msg);
        // msg = "Mixing: \n" + msg;
        for (int i = 0; i < msg.Length; i++) { 
            subsTxt.text = subsTxt.text + msg[i];
            yield return new WaitForSeconds(0.03f);            
        }
        Game.ins.msgCompleted = true;
    }

    public void Reset() {
        addingHeat = false;       
        addingCold = false;
        UpdateTemperature();  
    }

    public void SwitchHeat() {
        addingHeat = !addingHeat;       
        addingCold = false;
        UpdateTemperature();
    }

    public void SwitchCold() {
        addingHeat = false;       
        addingCold = !addingCold;
        UpdateTemperature();
    }

    void UpdateTemperature() {
        imgHeat.SetActive(addingHeat);
        imgCold.SetActive(addingCold);    
        toggleCold.SetIsOnWithoutNotify(addingCold);
        toggleHeat.SetIsOnWithoutNotify(addingHeat);
    }


    public void ProcessMix() {
        if (procesing) return;
        StartCoroutine(ProcessMixCor());
    }

    IEnumerator ProcessMixCor() {
        if (Game.ins.CountSubsSelected() == 0) yield break;
        procesing = true;
        Temperature temperature = Temperature.normal;
        if (addingHeat) temperature = Temperature.heat;
        else if (addingCold) temperature = Temperature.cold;
        print("Mixing: " + subsSelected[0].ToString() + " " + subsSelected[1].ToString() + " " + subsSelected[2].ToString() + " " + subsSelected[3].ToString());
        SubstanceName subsResult = combineRecipes.FindRecipe(subsSelected[0], subsSelected[1], subsSelected[2], subsSelected[3], temperature);
        yield return new WaitForSeconds(0.5f);        
   //     print("removing from inventory: " + subsSelected[0].ToString());
        MtEvents.RemoveFromInventory(subsSelected[0]);
        yield return new WaitForSeconds(0.5f);
   //     print("removing from inventory: " + subsSelected[1].ToString());
        MtEvents.RemoveFromInventory(subsSelected[1]);
        yield return new WaitForSeconds(0.5f);
    //    print("removing from inventory: " + subsSelected[2].ToString());
        MtEvents.RemoveFromInventory(subsSelected[2]);
        yield return new WaitForSeconds(0.5f);
    //    print("removing from inventory: " + subsSelected[3].ToString());
        MtEvents.RemoveFromInventory(subsSelected[3]);
        yield return new WaitForSeconds(1f);
        MtEvents.DeselectAllInInventory();
        MtEvents.PutToInventory(subsResult);
        MtEvents.SelectInInventory(subsResult);
        MtEvents.UpdateSubstancesSelected(true);
        MtEvents.ProcessComplete();
        procesing = false;
    }


}
}