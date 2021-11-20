using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class PurgeInventory : MonoBehaviour {

    [SerializeField] PickeableSubstance[] pickeableGo;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (!Game.ins.IsInventoryEmpty()) MtEvents.ShowInventory();
            Invoke("Purge",1f);
        }
    }

    private void Purge() {
        foreach (PickeableSubstance item in pickeableGo) {
            item.gameObject.SetActive(true);
            item.Restart();
        }
        MtEvents.PurgeInventory();    
    }

}

}