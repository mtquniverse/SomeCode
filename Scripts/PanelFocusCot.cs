using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace MarcosQuijada.Chemibot
{

public class PanelFocusCot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler,IPointerExitHandler  {

    [SerializeField] InventarySlot[] inventarySlot;
    TweenEffects tweener;
    SubstanceName subsSelected = SubstanceName.None;
    [SerializeField] Image imageSubs;
    bool pointerOnPanel = false;
    void Start() {
        MtEvents.onUpdateSubstancesSelected += OnUpdateSubstancesSelected;
        MtEvents.onRestartMission += OnRestartMission;
        tweener = this.GetComponent<TweenEffects>();
    }

    private void OnDestroy() {
        MtEvents.onUpdateSubstancesSelected -= OnUpdateSubstancesSelected;
        MtEvents.onRestartMission -= OnRestartMission;
    }


    private void Update() {
        if (Game.ins.moving) {
            tweener.Hide();    
            MtEvents.DeselectAllInInventory();
        }
    }

    private void OnRestartMission() {
        tweener.Hide();
    }

    //Not using this
    private void OnUpdateSubstancesSelected(bool isAResult) {
        return;
        if (Game.ins.statusGame != StatusGame.Exploring) return;
//        if (Game.ins.statusGame == StatusGame.Mixing) return;
 //       if (Game.ins.statusGame == StatusGame.Separating) return;
        bool done = false;
        for (int i = 0; i < inventarySlot.Length; i++) {
            if (inventarySlot[i].IsSelected()) {
                done = true;
                if (tweener.IsHidden()) tweener.Recover();
                subsSelected = inventarySlot[i].substanceName;
                imageSubs.sprite =  Game.ins.substances.Sprite(subsSelected);
                break;
               // subsTxt.text = subsTxt.text + Game.ins.substances.Name(subsSelected[x])  + "\n";
            }
        }
        if (!done) if (!tweener.IsHidden()) tweener.Hide();
    }

    public void OnPointerDown(PointerEventData eventdata) {
        if (!pointerOnPanel) return;
        print("Hiding focus panel");
        tweener.Hide();
    }

    public void OnPointerExit(PointerEventData eventData) {
        pointerOnPanel = false;
    }

    public virtual void OnPointerEnter(PointerEventData eventData) {
        pointerOnPanel = false;
    }



}

}