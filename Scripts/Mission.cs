using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MarcosQuijada.Chemibot {
public class Mission : MonoBehaviour {

    public struct Story {
        public MissionStep step;    
        public string linetalk;
        public bool talkNPC;
        public FacesType face;   
        public SubstanceNeeded[] substancesNeeded;

    }


    public struct SubstanceNeeded {
        public SubstanceName subs;
        public SubsNeededType subsType;
        public string lineGetIt;
    }

    public Story[][] story = new Story[4][]; 


    private void Start() {
        Loadstory();
     }


    void Loadstory() {
        story[0] = new Story[19];
        story[1] = new Story[26];
        story[2] = new Story[26];
        story[3] = new Story[28];

        int m = 0;
        int s = 0;
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_01";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //1;
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_01";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;
        story[m][s].substancesNeeded = null;

        s++; //2
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_02";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;
        story[m][s].substancesNeeded = null;

        s++; //3
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_03";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;
        story[m][s].substancesNeeded = null;

        s++; //4
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Che1_02";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;
        story[m][s].substancesNeeded = new SubstanceNeeded[6];
        story[m][s].substancesNeeded[0].subs = SubstanceName.AncientMedicine;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl1_04G";
        story[m][s].substancesNeeded[1].subs = SubstanceName.AncientMedicineFailed;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl1_04T";
        story[m][s].substancesNeeded[2].subs = SubstanceName.LemonBakingSoda;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[2].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[3].subs = SubstanceName.WaterBakingsoda;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[3].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[4].subs = SubstanceName.WaterLemon;
        story[m][s].substancesNeeded[4].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[4].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[5].subs = SubstanceName.None;
        story[m][s].substancesNeeded[5].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[5].lineGetIt = "YouFailedSub";

        s++; //5
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_041";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //6
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_03";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //7
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_04";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //8
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_052";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //9
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_05";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //10
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Che1_05";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[7];
        story[m][s].substancesNeeded[0].subs = SubstanceName.CoffeAndResidual;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl1_06B";
        story[m][s].substancesNeeded[1].subs = SubstanceName.CoffeAndResidualFailed;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl1_06B";
        story[m][s].substancesNeeded[2].subs = SubstanceName.CoffeSugarAndResidual;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[2].lineGetIt = "Girl1_06";
        story[m][s].substancesNeeded[3].subs = SubstanceName.CoffeSugarAndResidualFailed;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[3].lineGetIt = "Girl1_06B";
        story[m][s].substancesNeeded[4].subs = SubstanceName.PowderCoffeSugar;
        story[m][s].substancesNeeded[4].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[4].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[5].subs = SubstanceName.WaterSugar;
        story[m][s].substancesNeeded[5].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[5].lineGetIt = "Halfway";  
        story[m][s].substancesNeeded[6].subs = SubstanceName.None;
        story[m][s].substancesNeeded[6].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[6].lineGetIt = "YouFailedSub";      

        s++; //11
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_06";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;

        s++; //12
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_062";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = null;
        
        
        s++; //13
        story[m][s].step = MissionStep.Separate;
        story[m][s].linetalk = "Girl1_07_1";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[5];
        story[m][s].substancesNeeded[0].subs = SubstanceName.Coffe;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl1_07G";
        story[m][s].substancesNeeded[1].subs = SubstanceName.CoffeFailed;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl1_07T";
        story[m][s].substancesNeeded[2].subs = SubstanceName.CoffeNoSugar;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[2].lineGetIt = "Girl1_07N";
        story[m][s].substancesNeeded[3].subs = SubstanceName.CoffeNoSugarFailed;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[3].lineGetIt = "Girl1_07TN";
        story[m][s].substancesNeeded[4].subs = SubstanceName.None;
        story[m][s].substancesNeeded[4].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[4].lineGetIt = "YouFailedSub";  

        s++; //14
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_07";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;

        s++; //15
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_08";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;

        s++; //16
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_09";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;

        s++; //17
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl1_08";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //18
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che1_01_2";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;

        //************************************* Mission 1 *****************************************
        m = 1; 
        s = 0;
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_01";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;

        s++; //1
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_02";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;

        s++; //2
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_03";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;

        s++; //3
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_04";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Sad;

        s++; //4
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_05";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        
        s++; //5
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Che2_041";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;       
        story[m][s].substancesNeeded = new SubstanceNeeded[5];
        story[m][s].substancesNeeded[0].subs = SubstanceName.SandCementGravel;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[0].lineGetIt = "Boy2_06";
        story[m][s].substancesNeeded[1].subs = SubstanceName.SandCement;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[1].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[2].subs = SubstanceName.SandGravel;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[2].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[3].subs = SubstanceName.CementGravel;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[3].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[4].subs = SubstanceName.None;
        story[m][s].substancesNeeded[4].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[4].lineGetIt = "YouFailedSub";      

        s++; //6
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_061";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;

        s++; //7
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_07";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Surprised;

        s++; //8
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_08";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;

        s++; //9
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_09";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;

        s++; //10
        story[m][s].step = MissionStep.Separate;
        story[m][s].linetalk = "Che2_091";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[2];
        story[m][s].substancesNeeded[0].subs = SubstanceName.SandCement;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[0].lineGetIt = "Che2_092";
        story[m][s].substancesNeeded[1].subs = SubstanceName.None;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[1].lineGetIt = "YouFailedSub";

        s++; //11
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_09G";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //12
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_10";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;   

        s++; //13
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Che2_10";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;    
        story[m][s].substancesNeeded = new SubstanceNeeded[2];
        story[m][s].substancesNeeded[0].subs = SubstanceName.FinishMortar;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[0].lineGetIt = "Che2_11";
        story[m][s].substancesNeeded[1].subs = SubstanceName.None;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[1].lineGetIt = "YouFailedSub";        

        s++; //14
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_11";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //15
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_12";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;

        s++; //16
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_13";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Confused;    

        s++; //17
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_14";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;       

        s++; //18
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_15";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;      

        s++; //19
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_12";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Confused;     

        s++; //20
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_16";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;       

        s++; //21
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_16";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Confused;     

        s++; //22
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_17";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Angry;     

        s++; //23
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_18";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Confused;     

        s++; //24
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy2_17";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;       

        s++; //25
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che2_15";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Angry;     

        //************************************* Mission 2 *****************************************
        m = 2; 
        s = 0;
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_01";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;     

        s++; //1
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_02";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Confused;

        s++; //2
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_03";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;     

        s++; //3
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_04";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;     

        s++; //4
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_05";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;     

        s++; //5
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_051";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;    

        s++; //6
        story[m][s].step = MissionStep.Separate;
        story[m][s].linetalk = "Boy3_06";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;     
        story[m][s].substancesNeeded = new SubstanceNeeded[4];
        story[m][s].substancesNeeded[0].subs = SubstanceName.Peanuts;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[0].lineGetIt = "Boy3_07";
        story[m][s].substancesNeeded[1].subs = SubstanceName.Salt;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[1].lineGetIt = "Boy3_07";
        story[m][s].substancesNeeded[2].subs = SubstanceName.Clips;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[2].lineGetIt = "Boy3_101";   
        story[m][s].substancesNeeded[3].subs = SubstanceName.None;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[3].lineGetIt = "YouFailedSub";      

        s++; //7
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_08";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     

        s++; //8
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_03";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;  

        s++; //9
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_06";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;  

        s++; //10
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_091";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     

        s++; //11
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_061";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;  

        s++; //12
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_062";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;  

        s++; //13
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_063";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;  

        s++; //14
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_09";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     

        s++; //15
        story[m][s].step = MissionStep.Separate;
        story[m][s].linetalk = "Boy3_10";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     
        story[m][s].substancesNeeded = new SubstanceNeeded[4];
        story[m][s].substancesNeeded[0].subs = SubstanceName.MetalNuts;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[0].lineGetIt = "Boy3_07";
        story[m][s].substancesNeeded[1].subs = SubstanceName.Marbles;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[1].lineGetIt = "Boy3_101";
        story[m][s].substancesNeeded[2].subs = SubstanceName.CatsSand;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[2].lineGetIt = "Boy3_101";
        story[m][s].substancesNeeded[3].subs = SubstanceName.None;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[3].lineGetIt = "Boy3_10W";      

        s++; //16
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_11_1";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;   

        s++; //17
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_11";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;   

        s++; //18
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_05";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Confused;

        s++; //19
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_12";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;   

        s++; //20
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_07";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Sad;

        s++; //21
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_071";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Sad;

        s++; //22
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_08";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Sad;
      
        s++; //23
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_13";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Sad;   

        s++; //24
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che3_09";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Sad;
        
        s++; //25
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Boy3_14";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;   


        //************************************* Mission 3 *****************************************
        m = 3; 
        s = 0;
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_01";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     

        s++; //1
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che4_01";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;     

        s++; //2
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_03";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     

        s++; //3
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che4_02";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;     

        s++; //4
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_04";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     

        s++; //5
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Che4_03";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;     
        story[m][s].substancesNeeded = new SubstanceNeeded[12];
        story[m][s].substancesNeeded[0].subs = SubstanceName.CakeMix;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.IsMust;
        story[m][s].substancesNeeded[0].lineGetIt = "Che4_04";
        story[m][s].substancesNeeded[1].subs = SubstanceName.EggsFlour;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[1].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[2].subs = SubstanceName.EggsFlourMilk;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[2].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[3].subs = SubstanceName.EggsMilk;
        story[m][s].substancesNeeded[3].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[3].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[4].subs = SubstanceName.EggsSugarFlour;
        story[m][s].substancesNeeded[4].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[4].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[5].subs = SubstanceName.EggsSugar;
        story[m][s].substancesNeeded[5].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[5].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[6].subs = SubstanceName.EggsSugarMilk;
        story[m][s].substancesNeeded[6].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[6].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[7].subs = SubstanceName.SugarFlour;
        story[m][s].substancesNeeded[7].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[7].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[8].subs = SubstanceName.SugarFlourMilk;
        story[m][s].substancesNeeded[8].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[8].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[9].subs = SubstanceName.SugarMilk;
        story[m][s].substancesNeeded[9].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[9].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[10].subs = SubstanceName.FlourMilk;
        story[m][s].substancesNeeded[10].subsType = SubsNeededType.halfWay;
        story[m][s].substancesNeeded[10].lineGetIt = "Halfway";
        story[m][s].substancesNeeded[11].subs = SubstanceName.None;
        story[m][s].substancesNeeded[11].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[11].lineGetIt = "YouFailedSub";    

        s++; //6
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_04G";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;    

        s++; //7
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_05";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;    

        s++; //8
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Girl4_06";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[3];
        story[m][s].substancesNeeded[0].subs = SubstanceName.Cake;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl4_06G";        
        story[m][s].substancesNeeded[1].subs = SubstanceName.CakeFailed;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl4_06B";        
        story[m][s].substancesNeeded[2].subs = SubstanceName.None;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[2].lineGetIt = "YouFailedSub";    

        s++; //9
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_07";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;    

        s++; //10
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_08";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;    

        s++; //11
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_09";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;    

        s++; //12
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che_4_05";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;   

        s++; //13
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che_4_06";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;   

        s++; //14
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che_4_07";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;   

        s++; //15
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_10";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //16
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Girl4_11";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[3];
        story[m][s].substancesNeeded[0].subs = SubstanceName.GelatineMix;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl4_11G";        
        story[m][s].substancesNeeded[1].subs = SubstanceName.FailedGelatineMix;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl4_11W";        
        story[m][s].substancesNeeded[2].subs = SubstanceName.None;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[2].lineGetIt = "YouFailedSub";    

        s++; //17
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che_4_08";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;   

        s++; //18
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_12";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //19
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Girl4_13";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[3];
        story[m][s].substancesNeeded[0].subs = SubstanceName.Gelatine;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl4_13G";        
        story[m][s].substancesNeeded[1].subs = SubstanceName.FailedGelatine;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl4_13W";        
        story[m][s].substancesNeeded[2].subs = SubstanceName.None;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[2].lineGetIt = "YouFailedSub";    

        s++; //20
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che_4_09";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;   

        s++; //21
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_14";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //22
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Girl4_15";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[3];
        story[m][s].substancesNeeded[0].subs = SubstanceName.PudinMix;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl4_15G";        
        story[m][s].substancesNeeded[1].subs = SubstanceName.FailedPudinMix;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl4_15W";        
        story[m][s].substancesNeeded[2].subs = SubstanceName.None;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[2].lineGetIt = "YouFailedSub";   

        s++; //23
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_16";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //24
        story[m][s].step = MissionStep.Mix;
        story[m][s].linetalk = "Girl4_17";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
        story[m][s].substancesNeeded = new SubstanceNeeded[3];
        story[m][s].substancesNeeded[0].subs = SubstanceName.Pudin;
        story[m][s].substancesNeeded[0].subsType = SubsNeededType.posibleCorrect;
        story[m][s].substancesNeeded[0].lineGetIt = "Girl4_17G";        
        story[m][s].substancesNeeded[1].subs = SubstanceName.FailedPudin;
        story[m][s].substancesNeeded[1].subsType = SubsNeededType.posibleWrong;
        story[m][s].substancesNeeded[1].lineGetIt = "Girl4_17W";        
        story[m][s].substancesNeeded[2].subs = SubstanceName.None;
        story[m][s].substancesNeeded[2].subsType = SubsNeededType.youfailed;
        story[m][s].substancesNeeded[2].lineGetIt = "YouFailedSub";    

        s++; //25
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Che_4_10";
        story[m][s].talkNPC = false;
        story[m][s].face = FacesType.Happy;   

        s++; //26
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_18";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;

        s++; //27
        story[m][s].step = MissionStep.Talk;
        story[m][s].linetalk = "Girl4_18_1";
        story[m][s].talkNPC = true;
        story[m][s].face = FacesType.Happy;
    }


    public int CheckNewSubstance(int x, int i, SubstanceName subs) {
    //    foreach (SubstanceNeeded subsNeed in story[i].substancesNeeded) {
     //       print ("Check if " + subs.ToString() + " = " + subsNeed.subs);
      //      if (subsNeed.subs == subs) {
       //         return subsNeed. .subsType;
        //    }
     //   }
        for (int j = 0; j < story[x][i].substancesNeeded.Length; j++) {
            print("Checking if: "  + subs + " = " + story[x][i].substancesNeeded[j].subs);
            if (story[x][i].substancesNeeded[j].subs == subs) {
                return j;
            }
        } 
        return  (story[x][i].substancesNeeded.Length - 1);
    }


}

}