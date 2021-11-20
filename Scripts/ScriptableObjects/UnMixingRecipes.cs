using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

[CreateAssetMenu]
public class UnMixingRecipes : ScriptableObject {

    public SubstanceName[] idSubstance;
    public bool[] workFilter;
    public SubstanceName[] filterSubs;
    public SubstanceName[] noFilterSubs;
    public bool[] workSifter;
    public SubstanceName[] sifterSubs;
    public SubstanceName[] noSifterSubs;
    public bool[] workMagnet;
    public SubstanceName[] magnetizedSubs;
    public SubstanceName[] noMagnetizedSubs;


/*     *******************   Only used when I was developing as first load ******** 
    public void Preload() {
        for (int i = 0; i < Game.ins.substances.idSubstance.Length; i++) {
            idSubstance[i] = Game.ins.substances.idSubstance[i];
            workFilter[i] = false;
            filterSubs[i] = idSubstance[i];
            noFilterSubs[i] = SubstanceName.None;
            workSifter[i] = false;
            sifterSubs[i] = idSubstance[i];
            noSifterSubs[i] = SubstanceName.None;
            workMagnet[i] = false;
            magnetizedSubs[i] = SubstanceName.None;
            noMagnetizedSubs[i] = idSubstance[i];
        }
    }
*/


    int FindId(SubstanceName substanceName) {
        for (int i = 0; i < idSubstance.Length; i++) {
            if (idSubstance[i] == substanceName) {
                return i;
            }
        }   
        return 0; 
    }


    public bool AreRequiredInInventory(SubstanceName substanceName ) {
        for (int i = 0; i < idSubstance.Length; i++) {
            if ( (filterSubs[i] == substanceName) ||
                 (noFilterSubs[i] == substanceName) ||
                 (sifterSubs[i] == substanceName) ||
                 (noSifterSubs[i] == substanceName) ||
                 (magnetizedSubs[i] == substanceName) ||
                 (noMagnetizedSubs[i] == substanceName) ) {
                //if a resutl is in the recipe
                if (Game.ins.IsInInventory(idSubstance[i])) return true;
            }
        }   
        return false;
    }


    public bool WorkFilter(SubstanceName substanceName) {
        return workFilter[FindId(substanceName)];
    }

    public SubstanceName FilterSubs(SubstanceName substanceName) {
        return filterSubs[FindId(substanceName)];
    }

    public SubstanceName NoFilterSubs(SubstanceName substanceName) {
        return noFilterSubs[FindId(substanceName)];
    }

    public bool WorkSifter(SubstanceName substanceName) {
        return workFilter[FindId(substanceName)];
    }

    public SubstanceName SifterSubs(SubstanceName substanceName) {
        return sifterSubs[FindId(substanceName)];
    }
 
    public SubstanceName NoSifterSubs(SubstanceName substanceName) {
        return noSifterSubs[FindId(substanceName)];
    }
 
    public bool WorkMagnet(SubstanceName substanceName) {
        return workMagnet[FindId(substanceName)];
    }
 
    public SubstanceName MagnetizedSubs(SubstanceName substanceName) {
        return magnetizedSubs[FindId(substanceName)];
    }
 
    public SubstanceName NoMagnetizedSubs(SubstanceName substanceName) {
        return noMagnetizedSubs[FindId(substanceName)];
    }

}
}