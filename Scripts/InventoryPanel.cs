using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class InventoryPanel : MonoBehaviour {
 
    [SerializeField] InventarySlot[] inventarySlot;
    [SerializeField] ParticleSystem particleEffect;
    [SerializeField] TweenEffects tweener;
    [SerializeField] Transform playerTr;
    [SerializeField] Camera myCamera;
 
    bool pickingsub = false; 
    float timeToHide = -10;
    void Start() {
        MtEvents.onPickupSubstance += OnPickupSubstance;
        MtEvents.onPutToInventory += OnPutToInventory;
        MtEvents.onUpdateSubstancesSelected += OnUpdateSubstancesSelected;
        MtEvents.onShowInventory += OnShowInventory;
    }

    private void OnDestroy() {
        MtEvents.onPickupSubstance -= OnPickupSubstance;
        MtEvents.onPutToInventory -= OnPutToInventory;    
        MtEvents.onUpdateSubstancesSelected -= OnUpdateSubstancesSelected;
        MtEvents.onShowInventory -= OnShowInventory;
    }

    void Update() {
        if (Game.ins.statusGame != StatusGame.Exploring) return; 

        timeToHide -= Time.deltaTime;
        if ((timeToHide < 0) && (timeToHide > -10)) {
            tweener.Hide();
            timeToHide = -100;
        }
    }

    public void OnShowInventory() {
        tweener.Recover();
        timeToHide = 3;
    }

    public void OnUpdateSubstancesSelected(bool isAResult) {
        timeToHide = 3;
    }

    public void OnPutToInventory(SubstanceName subs) {
        foreach (InventarySlot invSlot in inventarySlot) {
            if (invSlot.substanceName == SubstanceName.None)  {
                invSlot.UpdateSubstance(subs);
                break;
            }   
        }
    }

    public void OnPickupSubstance(SubstanceName substanceName, Vector3 posi) {
        StartCoroutine(PickingSubstance(substanceName, posi));
    }

    IEnumerator PickingSubstance(SubstanceName substanceName, Vector3 posi){
        pickingsub = true;
        particleEffect.transform.position = new Vector3(posi.x, 2f, posi.z);
        particleEffect.Stop();
        particleEffect.Play();
        tweener.Recover();
        yield return new WaitForSeconds(0.3f);      
        foreach (InventarySlot invSlot in inventarySlot) {
            if (invSlot.substanceName == SubstanceName.None)  {
                invSlot.UpdateSubstance(substanceName);
                break;
            }
        }
        pickingsub = false;
        timeToHide = 3;
    }
    IEnumerator PickingSubstanceTweener() {
        tweener.Recover();
        yield return new WaitForSeconds(3f);      
        tweener.Hide();   
    }


} 

}
