using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

[CreateAssetMenu]
public class Substances : ScriptableObject
{

    public SubstanceName[] idSubstance;
    public string[] ObjectName;
    public Sprite[] inventorySprite;


    public Sprite Sprite(SubstanceName substanceName) {
        for (int i = 0; i < idSubstance.Length; i++) {
            if (idSubstance[i] == substanceName) {
                return inventorySprite[i];
            }
        }
        return inventorySprite[0];
    }

    public string Name(SubstanceName substanceName) {
        for (int i = 0; i < idSubstance.Length; i++) {
            if (idSubstance[i] == substanceName) {
                return ObjectName[i];
            }
        }
        return ObjectName[0];
    }


    public void UpdateNames() {
        for (int i = 0; i < idSubstance.Length; i++) {
           ObjectName[i] =  Game.ins.GetText(idSubstance[i].ToString());           
        }
    }


}

}
