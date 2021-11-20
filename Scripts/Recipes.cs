using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

[System.Serializable]
public class Recipes 
{

        public string  testString = "My test string";
        public SubstanceName[] subsCombination =  {SubstanceName.None, SubstanceName.None, SubstanceName.None, SubstanceName.None}; //new SubstanceName[4];
        public SubstanceName substanceResult, substanceResultCold, substanceResultHot;

        public void SubstanceResult(SubstanceName result) {
            substanceResult = result;
            substanceResultCold = result;
            substanceResultHot = result;        
        }
        public void SubstanceResult(SubstanceName result, SubstanceName resultCold, SubstanceName resultHot) {
            substanceResult = result;
            substanceResultCold = resultCold;
            substanceResultHot = resultHot;        
        }

        private void Start() {
            subsCombination[0] = SubstanceName.None;
            subsCombination[1] = SubstanceName.None;
            subsCombination[3] = SubstanceName.None;
            subsCombination[4] = SubstanceName.None;    
        }

        public void NewRecipe(SubstanceName sub1) {
            NewRecipe(sub1, SubstanceName.None, SubstanceName.None, SubstanceName.None);
        }
        public void NewRecipe(SubstanceName sub1, SubstanceName sub2) {
            NewRecipe(sub1, sub2, SubstanceName.None, SubstanceName.None);
        }
        public void NewRecipe(SubstanceName sub1, SubstanceName sub2, SubstanceName sub3) {
            NewRecipe(sub1, sub2, sub3, SubstanceName.None);        
        }
        public void NewRecipe(SubstanceName sub1, SubstanceName sub2, SubstanceName sub3, SubstanceName sub4) {
            subsCombination[0] = sub1;
            subsCombination[1] = sub2;
            subsCombination[3] = sub3;
            subsCombination[4] = sub4;        
        }
    }



}

