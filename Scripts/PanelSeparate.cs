using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace MarcosQuijada.Chemibot {

public class PanelSeparate : MonoBehaviour {

    [SerializeField] InventarySlot[] inventarySlot;
    [SerializeField] Image imageKeep, imagePass;
    SubstanceName subsKeep, subsPass;

    bool usingFilter = false;
    bool usingSifter = false;
    bool usingMagnet = false;

    IEnumerator fillTextCoroutine;
    [SerializeField] GameObject imgFilter, imgSifter, imgMagnet;
    [SerializeField] Toggle toggleFilter, ToggleSifter, ToggleMagnet;
    [SerializeField] UnMixingRecipes unMixingRecipes;
    [SerializeField] GameObject particleDown, particleDone1, particleDone2;
    [SerializeField] TMP_Text subsTxt;
    TweenEffects tweener;
    string textMsg = "";
    bool procesing = false;

    private void Start() {
        MtEvents.onUpdateSubstancesSelected += OnUpdateSubstancesSelected;    
        MtEvents.onShowMessage += OnShowMessage;
        MtEvents.onRestartMission += OnRestartMission;    
        MtEvents.onChangeStatusGame += Reset;        
        tweener = this.GetComponent<TweenEffects>();    
    }

    private void OnDestroy() {
        MtEvents.onUpdateSubstancesSelected -= OnUpdateSubstancesSelected;    
        MtEvents.onShowMessage -= OnShowMessage;
        MtEvents.onRestartMission -= OnRestartMission;
        MtEvents.onChangeStatusGame -= Reset;
    }

    void OnShowMessage(string lineTalk, bool talkFast) {
        if (Game.ins.statusGame == StatusGame.Separating) FillText(Game.ins.GetText(lineTalk,true));
    }


    private void OnUpdateSubstancesSelected(bool isAResult) {
        if (Game.ins.statusGame != StatusGame.Separating) return; 
        if (isAResult) textMsg = Game.ins.GetText("YouGot");
        else UpdateTextPred();      
        subsKeep = SubstanceName.None;
        subsPass = SubstanceName.None;
        imageKeep.sprite = Game.ins.substances.Sprite(subsKeep);
        imagePass.sprite = Game.ins.substances.Sprite(subsPass);
        for (int i  = 0; i < inventarySlot.Length; i++) {
            if (inventarySlot[i].IsSelected()) {
                subsKeep = inventarySlot[i].substanceName;
                textMsg =  textMsg + Game.ins.substances.Name(subsKeep)  + "\n";
                imageKeep.sprite = Game.ins.substances.Sprite(subsKeep);
            }
        }
        FillText(textMsg);
    }

    void UpdateTextPred() {
        textMsg = "";
        if (usingFilter) textMsg = Game.ins.GetText("Filtering");  
        if (usingSifter) textMsg = Game.ins.GetText("Sifting");  
        if (usingMagnet) textMsg = Game.ins.GetText("Magnetizing");
    
    }


    void OnRestartMission() {
        tweener.Hide();
    }


    void UpdateProcess() {
        UpdateTextPred();
        imgFilter.SetActive(usingFilter);
        imgSifter.SetActive(usingSifter);
        imgMagnet.SetActive(usingMagnet);   
        toggleFilter.SetIsOnWithoutNotify(usingFilter);
        ToggleSifter.SetIsOnWithoutNotify(usingSifter);
        ToggleMagnet.SetIsOnWithoutNotify(usingMagnet);
        MtEvents.UpdateSubstancesSelected();
    }


    private void Reset() {
        usingFilter = false;       
        usingSifter = false;
        usingMagnet = false;
        UpdateProcess();
    }

    public void SwitchFilter() {
        usingFilter = !usingFilter;       
        usingSifter = false;
        usingMagnet = false;
        UpdateProcess();
    }

    public void SwitchSifter() {
        usingFilter = false;       
        usingSifter = !usingSifter;
        usingMagnet = false;
        UpdateProcess();
    }

    public void SwitchMagnet() {
        usingFilter = false;       
        usingSifter = false;
        usingMagnet = !usingMagnet;
        UpdateProcess();
    }


    public void ProcessSubstance() {
        if (procesing) return;
        StartCoroutine(ProcessSubstanceCor());
    }

    IEnumerator ProcessSubstanceCor() {
    print("Substances Selected: " + Game.ins.CountSubsSelected());
    if (Game.ins.CountSubsSelected() == 0) yield break;
    if (!usingFilter && !usingMagnet && !usingSifter) yield break;
    procesing = true;
    SubstanceName subsResult = SubstanceName.None;
    SubstanceName subsRetained = SubstanceName.None;
    Game.ins.soundSeparating.Play();
    particleDown.SetActive(false);
    particleDown.SetActive(true);
    if (usingFilter) {
        subsRetained = unMixingRecipes.FilterSubs(subsKeep);
        subsResult = unMixingRecipes.NoFilterSubs(subsKeep);
    } else if (usingSifter) {
        subsRetained = unMixingRecipes.NoSifterSubs(subsKeep);
        subsResult = unMixingRecipes.SifterSubs(subsKeep);
    } else if (usingMagnet) {
        subsRetained = unMixingRecipes.MagnetizedSubs(subsKeep);
        subsResult = unMixingRecipes.NoMagnetizedSubs(subsKeep);    
    } else {
        subsRetained = subsKeep;
        subsResult = SubstanceName.None;
    }
    yield return new WaitForSeconds(1f);
    MtEvents.RemoveFromInventory(subsKeep);
    yield return new WaitForSeconds(1f);
    if (subsRetained != SubstanceName.Water) MtEvents.PutToInventory(subsRetained);
    particleDone1.SetActive(false);
    particleDone1.SetActive(true);
    imageKeep.sprite = Game.ins.substances.Sprite(subsRetained);
//    yield return new WaitForSeconds(1f);
    if (subsResult != SubstanceName.None) {
        particleDone2.SetActive(false);
        particleDone2.SetActive(true);
    }
    if (subsResult != SubstanceName.Water) MtEvents.PutToInventory(subsResult);
    imagePass.sprite = Game.ins.substances.Sprite(subsResult);
    subsKeep = subsRetained;
    subsPass = subsResult;
    MtEvents.ProcessComplete();
    yield return new WaitForSeconds(0.3f);
    procesing = false;
    }


    public void FillText(string msg) {
        if (fillTextCoroutine != null) StopCoroutine(fillTextCoroutine);
        fillTextCoroutine = FillingTextCor(msg);
        StartCoroutine(fillTextCoroutine);
    }
    IEnumerator FillingTextCor(string msg) {
        Game.ins.msgCompleted = false;
        subsTxt.text = "";
        print("msg to show: " + msg);
        //msg = "Mixing: \n" + msg;

        for (int i = 0; i < msg.Length; i++) { 
            subsTxt.text = subsTxt.text + msg[i];
            // audio step
            yield return new WaitForSeconds(0.03f);            
        }
        Game.ins.msgCompleted = true;
    }


}
}
