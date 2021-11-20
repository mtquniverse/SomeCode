using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {


public class CombineRecipes : MonoBehaviour {

    public struct Recipe {
        public SubstanceName[] subsCombination;
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


            public void NewRecipe(SubstanceName sub1, SubstanceName sub2 = SubstanceName.None, 
                                  SubstanceName sub3 = SubstanceName.None, SubstanceName sub4 = SubstanceName.None) {
                subsCombination[0] = sub1;
                subsCombination[1] = sub2;
                subsCombination[2] = sub3;
                subsCombination[3] = sub4;        
            }
        }


        public Recipe[] recipes = new Recipe[108]; 


        void StartRecipe() {
            for (int i = 0; i < recipes.Length; i++) {
                recipes[i].subsCombination = new SubstanceName[4];
            }
        }



        IEnumerator Start() {
        StartRecipe();
        yield return new WaitForSeconds(1);
       
     
        recipes[0].NewRecipe(SubstanceName.Water, SubstanceName.Lemon); 
        recipes[0].SubstanceResult(SubstanceName.WaterLemon);

        recipes[1].NewRecipe(SubstanceName.Water, SubstanceName.BakingSoda); 
        recipes[1].SubstanceResult(SubstanceName.WaterBakingsoda);
        
        recipes[2].NewRecipe(SubstanceName.Lemon, SubstanceName.BakingSoda); 
        recipes[2].SubstanceResult(SubstanceName.LemonBakingSoda);

        recipes[3].NewRecipe(SubstanceName.Water, SubstanceName.Sugar); 
        recipes[3].SubstanceResult(SubstanceName.WaterSugar);   

        recipes[4].NewRecipe(SubstanceName.Water, SubstanceName.Lemon, SubstanceName.Sugar); 
        recipes[4].SubstanceResult(SubstanceName.LemonadeFailed, SubstanceName.Lemonade, SubstanceName.LemonadeFailed);
        
        recipes[5].NewRecipe(SubstanceName.WaterLemon, SubstanceName.Sugar); 
        recipes[5].SubstanceResult(SubstanceName.LemonadeFailed, SubstanceName.Lemonade, SubstanceName.LemonadeFailed);

        recipes[6].NewRecipe(SubstanceName.WaterSugar, SubstanceName.Lemon); 
        recipes[6].SubstanceResult(SubstanceName.LemonadeFailed, SubstanceName.Lemonade, SubstanceName.LemonadeFailed);

        recipes[7].NewRecipe(SubstanceName.LemonadeFailed); 
        recipes[7].SubstanceResult(SubstanceName.LemonadeFailed, SubstanceName.Lemonade, SubstanceName.LemonadeFailed);
     
        recipes[8].NewRecipe(SubstanceName.Water, SubstanceName.Lemon, SubstanceName.BakingSoda); 
        recipes[8].SubstanceResult(SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicine);
        
        recipes[9].NewRecipe(SubstanceName.Water, SubstanceName.LemonBakingSoda); 
        recipes[9].SubstanceResult(SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicine);
        
        recipes[10].NewRecipe(SubstanceName.WaterBakingsoda, SubstanceName.Lemon); 
        recipes[10].SubstanceResult(SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicine);
        
        recipes[11].NewRecipe(SubstanceName.WaterLemon, SubstanceName.BakingSoda); 
        recipes[11].SubstanceResult(SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicine);
        
        recipes[12].NewRecipe(SubstanceName.AncientMedicineFailed); 
        recipes[12].SubstanceResult(SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicineFailed, SubstanceName.AncientMedicine);

        recipes[13].NewRecipe(SubstanceName.PowderCoffe, SubstanceName.Sugar); 
        recipes[13].SubstanceResult(SubstanceName.PowderCoffeSugar);

        recipes[14].NewRecipe(SubstanceName.Water, SubstanceName.PowderCoffe); 
        recipes[14].SubstanceResult(SubstanceName.CoffeAndResidualFailed, SubstanceName.CoffeAndResidualFailed, SubstanceName.CoffeAndResidual);

        recipes[15].NewRecipe(SubstanceName.Water, SubstanceName.PowderCoffe, SubstanceName.Sugar); 
        recipes[15].SubstanceResult(SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidual);

        recipes[16].NewRecipe(SubstanceName.Water, SubstanceName.PowderCoffeSugar); 
        recipes[16].SubstanceResult(SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidual);

        recipes[17].NewRecipe(SubstanceName.WaterSugar, SubstanceName.PowderCoffe); 
        recipes[17].SubstanceResult(SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidual);

        recipes[18].NewRecipe(SubstanceName.CoffeAndResidual, SubstanceName.Sugar); 
        recipes[18].SubstanceResult(SubstanceName.CoffeSugarAndResidual, SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidual);

        recipes[19].NewRecipe(SubstanceName.CoffeAndResidualFailed, SubstanceName.Sugar); 
        recipes[19].SubstanceResult(SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidual);

        recipes[20].NewRecipe(SubstanceName.CoffeSugarAndResidualFailed); 
        recipes[20].SubstanceResult(SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidualFailed, SubstanceName.CoffeSugarAndResidual);

        recipes[21].NewRecipe(SubstanceName.CoffeAndResidualFailed); 
        recipes[21].SubstanceResult(SubstanceName.CoffeAndResidualFailed, SubstanceName.CoffeAndResidualFailed, SubstanceName.CoffeAndResidual);
     
        recipes[22].NewRecipe(SubstanceName.TeHerbs, SubstanceName.Sugar); 
        recipes[22].SubstanceResult(SubstanceName.TeHerbsSugar);

        recipes[23].NewRecipe(SubstanceName.Water, SubstanceName.TeHerbs); 
        recipes[23].SubstanceResult(SubstanceName.TeHerbsAndResidualFailed, SubstanceName.TeHerbsAndResidualFailed, SubstanceName.TeHerbsAndResidual);

        recipes[24].NewRecipe(SubstanceName.Water, SubstanceName.TeHerbs, SubstanceName.Sugar); 
        recipes[24].SubstanceResult(SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidual);

        recipes[25].NewRecipe(SubstanceName.Water, SubstanceName.TeHerbsSugar); 
        recipes[25].SubstanceResult(SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidual);

        recipes[26].NewRecipe(SubstanceName.WaterSugar, SubstanceName.TeHerbs); 
        recipes[26].SubstanceResult(SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidual);

        recipes[27].NewRecipe(SubstanceName.TeHerbsAndResidual, SubstanceName.Sugar); 
        recipes[27].SubstanceResult(SubstanceName.TeHerbsSugarAndResidual, SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidual);

        recipes[28].NewRecipe(SubstanceName.TeHerbsAndResidualFailed, SubstanceName.Sugar); 
        recipes[28].SubstanceResult(SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidual);

        recipes[29].NewRecipe(SubstanceName.TeHerbsSugarAndResidualFailed); 
        recipes[29].SubstanceResult(SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidualFailed, SubstanceName.TeHerbsSugarAndResidual);

        recipes[30].NewRecipe(SubstanceName.TeHerbsAndResidualFailed); 
        recipes[30].SubstanceResult(SubstanceName.TeHerbsAndResidualFailed, SubstanceName.TeHerbsAndResidualFailed, SubstanceName.TeHerbsAndResidual);

        recipes[31].NewRecipe(SubstanceName.Sand, SubstanceName.Cement); 
        recipes[31].SubstanceResult(SubstanceName.SandCement);

        recipes[32].NewRecipe(SubstanceName.Sand, SubstanceName.Gravel); 
        recipes[32].SubstanceResult(SubstanceName.SandGravel);

        recipes[33].NewRecipe(SubstanceName.Cement, SubstanceName.Gravel); 
        recipes[33].SubstanceResult(SubstanceName.CementGravel);

        recipes[34].NewRecipe(SubstanceName.SandGravel, SubstanceName.Cement); 
        recipes[34].SubstanceResult(SubstanceName.SandCementGravel);

        recipes[35].NewRecipe(SubstanceName.SandCement, SubstanceName.Gravel); 
        recipes[35].SubstanceResult(SubstanceName.SandCementGravel);

        recipes[36].NewRecipe(SubstanceName.Sand, SubstanceName.CementGravel); 
        recipes[36].SubstanceResult(SubstanceName.SandCementGravel);

        recipes[37].NewRecipe(SubstanceName.Sand, SubstanceName.Water); 
        recipes[37].SubstanceResult(SubstanceName.SandWater);

        recipes[38].NewRecipe(SubstanceName.Gravel, SubstanceName.Water); 
        recipes[38].SubstanceResult(SubstanceName.GravelWater);

        recipes[39].NewRecipe(SubstanceName.SandGravel, SubstanceName.Water); 
        recipes[39].SubstanceResult(SubstanceName.SandGravelWater);

        recipes[40].NewRecipe(SubstanceName.Sand, SubstanceName.GravelWater); 
        recipes[40].SubstanceResult(SubstanceName.SandGravelWater);

        recipes[41].NewRecipe(SubstanceName.SandWater, SubstanceName.Gravel); 
        recipes[41].SubstanceResult(SubstanceName.SandGravelWater);

        recipes[42].NewRecipe(SubstanceName.Sand, SubstanceName.Gravel, SubstanceName.Water); 
        recipes[42].SubstanceResult(SubstanceName.SandGravelWater);

        recipes[43].NewRecipe(SubstanceName.Sand, SubstanceName.Gravel, SubstanceName.Cement); 
        recipes[43].SubstanceResult(SubstanceName.SandCementGravel);

        recipes[44].NewRecipe(SubstanceName.SandCement, SubstanceName.Water); 
        recipes[44].SubstanceResult(SubstanceName.FinishMortar);

        recipes[45].NewRecipe(SubstanceName.Sand, SubstanceName.Cement, SubstanceName.Water); 
        recipes[45].SubstanceResult(SubstanceName.FinishMortar);

        recipes[46].NewRecipe(SubstanceName.Cement, SubstanceName.Water); 
        recipes[46].SubstanceResult(SubstanceName.FailedMortar);

        recipes[47].NewRecipe(SubstanceName.SandCementGravel, SubstanceName.Water); 
        recipes[47].SubstanceResult(SubstanceName.Mortar);

        recipes[48].NewRecipe(SubstanceName.Sand, SubstanceName.CementGravel, SubstanceName.Water); 
        recipes[48].SubstanceResult(SubstanceName.Mortar);

        recipes[49].NewRecipe(SubstanceName.SandCement, SubstanceName.Gravel, SubstanceName.Water); 
        recipes[49].SubstanceResult(SubstanceName.Mortar);

        recipes[50].NewRecipe(SubstanceName.Sand, SubstanceName.Cement, SubstanceName.Gravel, SubstanceName.Water); 
        recipes[50].SubstanceResult(SubstanceName.Mortar);

        recipes[51].NewRecipe(SubstanceName.Clips, SubstanceName.Peanuts); 
        recipes[51].SubstanceResult(SubstanceName.ClipsPeanuts);

        recipes[52].NewRecipe(SubstanceName.Clips, SubstanceName.Salt); 
        recipes[52].SubstanceResult(SubstanceName.ClipsSalt);

        recipes[53].NewRecipe(SubstanceName.Peanuts, SubstanceName.Salt); 
        recipes[53].SubstanceResult(SubstanceName.PeanutsSalt);

        recipes[54].NewRecipe(SubstanceName.ClipsPeanuts, SubstanceName.Salt); 
        recipes[54].SubstanceResult(SubstanceName.ClipsPeanutsSalt);

        recipes[55].NewRecipe(SubstanceName.ClipsSalt, SubstanceName.Peanuts); 
        recipes[55].SubstanceResult(SubstanceName.ClipsPeanutsSalt);

        recipes[56].NewRecipe(SubstanceName.Clips, SubstanceName.PeanutsSalt); 
        recipes[56].SubstanceResult(SubstanceName.ClipsPeanutsSalt);

        recipes[57].NewRecipe(SubstanceName.Clips, SubstanceName.Peanuts, SubstanceName.Salt); 
        recipes[57].SubstanceResult(SubstanceName.ClipsPeanutsSalt);

        recipes[58].NewRecipe(SubstanceName.Marbles, SubstanceName.MetalNuts); 
        recipes[58].SubstanceResult(SubstanceName.MarblesNuts);

        recipes[59].NewRecipe(SubstanceName.Marbles, SubstanceName.CatsSand); 
        recipes[59].SubstanceResult(SubstanceName.MarblesCatsSand);

        recipes[60].NewRecipe(SubstanceName.MetalNuts, SubstanceName.CatsSand); 
        recipes[60].SubstanceResult(SubstanceName.NutsCatsSand);

        recipes[61].NewRecipe(SubstanceName.MarblesNuts, SubstanceName.CatsSand); 
        recipes[61].SubstanceResult(SubstanceName.MarblesNutsCatsSand);

        recipes[62].NewRecipe(SubstanceName.MarblesCatsSand, SubstanceName.MetalNuts); 
        recipes[62].SubstanceResult(SubstanceName.MarblesNutsCatsSand);

        recipes[63].NewRecipe(SubstanceName.Marbles, SubstanceName.NutsCatsSand); 
        recipes[63].SubstanceResult(SubstanceName.MarblesNutsCatsSand);

        recipes[64].NewRecipe(SubstanceName.Marbles, SubstanceName.MetalNuts, SubstanceName.CatsSand); 
        recipes[64].SubstanceResult(SubstanceName.MarblesNutsCatsSand);

        recipes[65].NewRecipe(SubstanceName.Eggs, SubstanceName.Sugar); 
        recipes[65].SubstanceResult(SubstanceName.EggsSugar);

        recipes[66].NewRecipe(SubstanceName.Eggs, SubstanceName.WheatFlour); 
        recipes[66].SubstanceResult(SubstanceName.EggsFlour);

        recipes[67].NewRecipe(SubstanceName.Eggs, SubstanceName.Milk); 
        recipes[67].SubstanceResult(SubstanceName.EggsMilk);

        recipes[68].NewRecipe(SubstanceName.Sugar, SubstanceName.WheatFlour); 
        recipes[68].SubstanceResult(SubstanceName.SugarFlour);

        recipes[69].NewRecipe(SubstanceName.Sugar, SubstanceName.Milk); 
        recipes[69].SubstanceResult(SubstanceName.SugarMilk);

        recipes[70].NewRecipe(SubstanceName.WheatFlour, SubstanceName.Milk); 
        recipes[70].SubstanceResult(SubstanceName.FlourMilk);

        recipes[71].NewRecipe(SubstanceName.EggsSugar, SubstanceName.WheatFlour); 
        recipes[71].SubstanceResult(SubstanceName.EggsSugarFlour);

        recipes[72].NewRecipe(SubstanceName.Eggs, SubstanceName.SugarFlour); 
        recipes[72].SubstanceResult(SubstanceName.EggsSugarFlour);

        recipes[73].NewRecipe(SubstanceName.EggsFlour, SubstanceName.Sugar); 
        recipes[73].SubstanceResult(SubstanceName.EggsSugarFlour);

        recipes[74].NewRecipe(SubstanceName.Eggs, SubstanceName.WheatFlour, SubstanceName.Sugar); 
        recipes[74].SubstanceResult(SubstanceName.EggsSugarFlour);

        recipes[75].NewRecipe(SubstanceName.EggsSugar, SubstanceName.Milk); 
        recipes[75].SubstanceResult(SubstanceName.EggsSugarMilk);

        recipes[76].NewRecipe(SubstanceName.Eggs, SubstanceName.SugarMilk); 
        recipes[76].SubstanceResult(SubstanceName.EggsSugarMilk);

        recipes[77].NewRecipe(SubstanceName.EggsMilk, SubstanceName.Sugar); 
        recipes[77].SubstanceResult(SubstanceName.EggsSugarMilk);

        recipes[78].NewRecipe(SubstanceName.Eggs, SubstanceName.Milk, SubstanceName.Sugar); 
        recipes[78].SubstanceResult(SubstanceName.EggsSugarMilk);

        recipes[79].NewRecipe(SubstanceName.EggsFlour, SubstanceName.Milk); 
        recipes[79].SubstanceResult(SubstanceName.EggsFlourMilk);

        recipes[80].NewRecipe(SubstanceName.Eggs, SubstanceName.FlourMilk); 
        recipes[80].SubstanceResult(SubstanceName.EggsFlourMilk);

        recipes[81].NewRecipe(SubstanceName.EggsMilk, SubstanceName.WheatFlour); 
        recipes[81].SubstanceResult(SubstanceName.EggsFlourMilk);

        recipes[82].NewRecipe(SubstanceName.Eggs, SubstanceName.Milk, SubstanceName.WheatFlour); 
        recipes[82].SubstanceResult(SubstanceName.EggsFlourMilk);

        recipes[83].NewRecipe(SubstanceName.SugarFlour, SubstanceName.Milk); 
        recipes[83].SubstanceResult(SubstanceName.SugarFlourMilk);

        recipes[84].NewRecipe(SubstanceName.Sugar, SubstanceName.FlourMilk); 
        recipes[84].SubstanceResult(SubstanceName.SugarFlourMilk);

        recipes[85].NewRecipe(SubstanceName.SugarMilk, SubstanceName.WheatFlour); 
        recipes[85].SubstanceResult(SubstanceName.SugarFlourMilk);

        recipes[86].NewRecipe(SubstanceName.Sugar, SubstanceName.Milk, SubstanceName.WheatFlour); 
        recipes[86].SubstanceResult(SubstanceName.SugarFlourMilk);

        recipes[87].NewRecipe(SubstanceName.Eggs, SubstanceName.Sugar, SubstanceName.WheatFlour, SubstanceName.Milk); 
        recipes[87].SubstanceResult(SubstanceName.CakeMix);

        recipes[88].NewRecipe(SubstanceName.EggsSugar, SubstanceName.WheatFlour, SubstanceName.Milk); 
        recipes[88].SubstanceResult(SubstanceName.CakeMix);

        recipes[89].NewRecipe(SubstanceName.EggsFlour, SubstanceName.Sugar, SubstanceName.Milk); 
        recipes[89].SubstanceResult(SubstanceName.CakeMix);

        recipes[90].NewRecipe(SubstanceName.EggsMilk, SubstanceName.Sugar, SubstanceName.WheatFlour); 
        recipes[90].SubstanceResult(SubstanceName.CakeMix);

        recipes[91].NewRecipe(SubstanceName.Eggs, SubstanceName.SugarFlour, SubstanceName.Milk); 
        recipes[91].SubstanceResult(SubstanceName.CakeMix);

        recipes[92].NewRecipe(SubstanceName.Eggs, SubstanceName.SugarMilk, SubstanceName.WheatFlour); 
        recipes[92].SubstanceResult(SubstanceName.CakeMix);

        recipes[93].NewRecipe(SubstanceName.Eggs, SubstanceName.Sugar, SubstanceName.FlourMilk); 
        recipes[93].SubstanceResult(SubstanceName.CakeMix);

        recipes[94].NewRecipe(SubstanceName.EggsSugar, SubstanceName.FlourMilk); 
        recipes[94].SubstanceResult(SubstanceName.CakeMix);

        recipes[95].NewRecipe(SubstanceName.EggsFlour, SubstanceName.SugarMilk); 
        recipes[95].SubstanceResult(SubstanceName.CakeMix);

        recipes[96].NewRecipe(SubstanceName.EggsMilk, SubstanceName.SugarFlour); 
        recipes[96].SubstanceResult(SubstanceName.CakeMix);

        recipes[97].NewRecipe(SubstanceName.CakeMix); 
        recipes[97].SubstanceResult(SubstanceName.CakeMix, SubstanceName.CakeFailed, SubstanceName.Cake);
 
        recipes[98].NewRecipe(SubstanceName.PowderGelatine, SubstanceName.Water); 
        recipes[98].SubstanceResult(SubstanceName.FailedGelatineMix, SubstanceName.FailedGelatineMix, SubstanceName.GelatineMix);

        recipes[99].NewRecipe(SubstanceName.FailedGelatineMix); 
        recipes[99].SubstanceResult(SubstanceName.FailedGelatineMix, SubstanceName.FailedGelatine, SubstanceName.GelatineMix);

        recipes[100].NewRecipe(SubstanceName.GelatineMix); 
        recipes[100].SubstanceResult(SubstanceName.GelatineMix, SubstanceName.Gelatine, SubstanceName.GelatineMix);

        recipes[101].NewRecipe(SubstanceName.PowderPudin, SubstanceName.Water); 
        recipes[101].SubstanceResult(SubstanceName.FailedPudinMix, SubstanceName.FailedPudinMix, SubstanceName.PudinMix);

        recipes[102].NewRecipe(SubstanceName.FailedPudinMix); 
        recipes[102].SubstanceResult(SubstanceName.FailedPudinMix, SubstanceName.FailedPudin, SubstanceName.PudinMix);

        recipes[103].NewRecipe(SubstanceName.PudinMix); 
        recipes[103].SubstanceResult(SubstanceName.PudinMix, SubstanceName.Pudin, SubstanceName.PudinMix);

        recipes[104].NewRecipe(SubstanceName.Eggs, SubstanceName.SugarFlourMilk); 
        recipes[104].SubstanceResult(SubstanceName.CakeMix);

        recipes[105].NewRecipe(SubstanceName.Sugar, SubstanceName.EggsFlourMilk); 
        recipes[105].SubstanceResult(SubstanceName.CakeMix);

        recipes[106].NewRecipe(SubstanceName.WheatFlour, SubstanceName.EggsSugarMilk); 
        recipes[106].SubstanceResult(SubstanceName.CakeMix);

        recipes[107].NewRecipe(SubstanceName.Milk, SubstanceName.EggsSugarFlour); 
        recipes[107].SubstanceResult(SubstanceName.CakeMix);
        //If you have to add more, for some reason in the panel mix you have to increment the array there too
    }


    bool CheckCombinationInInventory(SubstanceName sub1, SubstanceName sub2, SubstanceName sub3, SubstanceName sub4) {
        if (sub1 != SubstanceName.None) if (!Game.ins.IsInInventory(sub1)) return false;
        if (sub2 != SubstanceName.None) if (!Game.ins.IsInInventory(sub2)) return false;
        if (sub3 != SubstanceName.None) if (!Game.ins.IsInInventory(sub3)) return false;
        if (sub4 != SubstanceName.None) if (!Game.ins.IsInInventory(sub4)) return false;
        return true;
    } 
    
    
    //To find if the materials needed to create a substance are in inventory
    public bool AreRequiredInInventory(SubstanceName subsToCreate) {
    //    print("recetas tamano: " + recipes.Length);
        for (int i = 0; i < recipes.Length; i++) {
            //If the recipe has as result the substance we are checking
            if ( (recipes[i].substanceResult == subsToCreate) ||
                (recipes[i].substanceResultCold == subsToCreate) ||
                (recipes[i].substanceResultHot == subsToCreate) ) {
                //If the combination is in the inventory we can break and tell that are the materials required are in inventory
                if (CheckCombinationInInventory(recipes[i].subsCombination[0], recipes[i].subsCombination[1],
                    recipes[i].subsCombination[2], recipes[i].subsCombination[3] )) {
                   // print();
                    return true;
                }
            }
        }
        return false;
    }


    bool CheckInList(SubstanceName subs, ref List<SubstanceName> subsList) {
        for (int i = 0; i < subsList.Count; i++) {
            if (subs == subsList[i]) {
                subsList.RemoveAt(i);
                return true;
            }
        }
        return false;
    } 


    public SubstanceName FindRecipe(SubstanceName subs1, Temperature temperature) {
        return FindRecipe(subs1, SubstanceName.None, SubstanceName.None, SubstanceName.None, temperature);    
    }
    public SubstanceName FindRecipe(SubstanceName subs1, SubstanceName subs2, Temperature temperature) {
        return FindRecipe(subs1, subs2, SubstanceName.None, SubstanceName.None, temperature);        
    }
    public SubstanceName FindRecipe(SubstanceName subs1, SubstanceName subs2, SubstanceName subs3, Temperature temperature) {
        return FindRecipe(subs1, subs2, subs3, temperature);       
    }

    public SubstanceName FindRecipe(SubstanceName subs1, SubstanceName subs2, SubstanceName subs3, SubstanceName subs4, Temperature temperature) {
        List<SubstanceName> subsRecipe = new List<SubstanceName>();
        bool done = false;
        for (int i = 0; i < recipes.Length; i++) {
            subsRecipe.Clear();
            for (int j = 0; j < 4; j++ ) 
                subsRecipe.Add(recipes[i].subsCombination[j]);
            done = false;
            if (CheckInList(subs1, ref subsRecipe) ) {
                if (CheckInList(subs2, ref subsRecipe) ) {
                    if (CheckInList(subs3, ref subsRecipe) ) {
                        if (CheckInList(subs4, ref subsRecipe) ) {
                            done = true;
                        }
                    }
                }
            }
            if (done) {
                if (temperature == Temperature.normal) return recipes[i].substanceResult;
                if (temperature == Temperature.cold) return recipes[i].substanceResultCold;
                if (temperature == Temperature.heat) return recipes[i].substanceResultHot;
            } 
        }
        //Especial Case No recipe
        if ((subs2 == SubstanceName.None) && (subs3 == SubstanceName.None) && (subs4 == SubstanceName.None)) return subs1; 
        else return SubstanceName.UnknowMix;
    }


}

}

