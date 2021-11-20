using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

namespace MarcosQuijada.Chemibot {

public class InventarySlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
   
    public int idSlot;
    [SerializeField] Image image;
    [SerializeField] InventoryPanel invPanel;
    [SerializeField] Substances substances;
    public SubstanceName substanceName = SubstanceName.None;
    [SerializeField] TMP_Text textName;
    [SerializeField] Sprite spriteEffect;
    [SerializeField] GameObject particleVanish;

    Sprite unSelectedSpr;
    Image frameImg;
    [SerializeField] Sprite selectedSpr;

    bool selected = false;


    void Start() {
        MtEvents.onRemoveFromInventory += OnRemoveFromInventory;
        MtEvents.onSelectInInventory += OnSelectInInventory;
        MtEvents.onChangeStatusGame += OnChangeStatusGame;
        MtEvents.onDeselectAllInInventory += OnDeselectAllInInventory;
        MtEvents.onPurgeInventory += OnPurgeInventory;
        UpdateSubstance(SubstanceName.None);
        frameImg = this.GetComponent<Image>();
        unSelectedSpr = frameImg.sprite;
    }

    private void OnDestroy() {
        MtEvents.onRemoveFromInventory -= OnRemoveFromInventory;
        MtEvents.onSelectInInventory -= OnSelectInInventory;
        MtEvents.onChangeStatusGame -= OnChangeStatusGame; 
        MtEvents.onDeselectAllInInventory -= OnDeselectAllInInventory;
        MtEvents.onPurgeInventory -= OnPurgeInventory;
    }




    public void UpdateSubstance(SubstanceName _substanceName) {
        StartCoroutine(UpdateSubstanceCor(_substanceName));
    }

    public IEnumerator UpdateSubstanceCor(SubstanceName _substanceName) {
        Sequence sequence;
        sequence = DOTween.Sequence();
        substanceName = _substanceName;
        image.sprite = spriteEffect;
        for (int i = 0; i < 7; i++) {
            sequence.Append(image.transform.DOScale(0, 0));
            sequence.Append(image.transform.DOScale(1, 0.1f));        
        }
        sequence.Play();
        yield return new WaitForSeconds(0.6f);
        image.sprite = substances.Sprite(substanceName);
        textName.text = substances.Name(substanceName);
    }


    public void OnPointerEnter(PointerEventData eventData) {
    }
    public void OnPointerExit(PointerEventData eventData) {
    }
    public void OnPointerDown(PointerEventData eventData) {
        if (!selected) {
            if (substanceName == SubstanceName.None) return;
            SelectSlot();
        } else  {
            UnSelectSlot();
        }
        MtEvents.UpdateSubstancesSelected();
    }

    void SelectSlot() {
        if (Game.ins.statusGame == StatusGame.Mixing) {
            if (Game.ins.CountSubsSelected() >= 4) return;
        } else {
            MtEvents.DeselectAllInInventory();
        }
        this.transform.localScale = new Vector3(1.3f,1.3f,1f);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 23, 0);
        frameImg.sprite = selectedSpr;
        selected = true;
    }

    void UnSelectSlot() {
        this.transform.localScale = new Vector3(1f,1f,1f);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0, 0);
        frameImg.sprite = unSelectedSpr;
        selected = false;        
    }

    public void OnDeselectAllInInventory() {
        if (selected) UnSelectSlot();       
    }

    public void OnSelectInInventory(SubstanceName subs){
        if (substanceName != subs) return;
        SelectSlot();
        MtEvents.UpdateSubstancesSelected();
    }
    public void OnChangeStatusGame() {
        if (!selected) return;
        if (Game.ins.statusGame != StatusGame.Focusing) UnSelectSlot();
    }

    public void OnPointerUp(PointerEventData eventData) {
    }
    public void OnBeginDrag(PointerEventData eventData) {
    }
    public void OnDrag(PointerEventData eventData) {
    }
    public void OnEndDrag(PointerEventData eventData) {
    }

    public bool IsSelected() {
        return selected;
    }

    public void OnRemoveFromInventory(SubstanceName subs) {
        if (subs == SubstanceName.None) return;
        if ((subs == SubstanceName.Water) && !(Game.ins.doingTutorial)) return;
        if (substanceName == subs) {
            RemoveFromInventory();
        } 
    }

    public void OnPurgeInventory() {
        RemoveFromInventory();
    }


    void RemoveFromInventory() {
        substanceName = SubstanceName.None;
        UpdateSubstance(substanceName);
        image.sprite = substances.Sprite(substanceName);
        textName.text = substances.Name(substanceName);
        this.transform.localScale = new Vector3(1f,1f,1f);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0, 0);
        frameImg.sprite = unSelectedSpr;
        selected = false;        
        particleVanish.SetActive(false);
        particleVanish.SetActive(true);
    }


}

}
