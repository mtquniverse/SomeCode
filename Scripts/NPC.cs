using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace MarcosQuijada.Chemibot {

public class NPC : MonoBehaviour {

    [SerializeField] FollowCamera followCamera;
    [SerializeField] Mission mission;
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text textMsg;
    [SerializeField] int idMission; //Id Story
    [SerializeField] Vector3 posiObj;
    [SerializeField] SelectFace selectFace;
    [SerializeField] PickeableSubstance[] substancesNedeed;
    [SerializeField] focusEnum focusMission = focusEnum.inside;
    [SerializeField] CombineRecipes combineRecipes;
    [SerializeField] UnMixingRecipes unMixingRecipes;
    bool doingMission = false;
    bool waitKey = false;

    bool initProgress = false;

    bool restartedMision = false;

    bool subsPutToInventory = false;
    SubstanceName substance;
    int idSubsNeeded;

    IEnumerator fillTextCoroutine;

    string msgGet = "", msgHalf = "", msgWrong = "", msg = "";


    void Start() {
        MtEvents.onProcessComplete += OnProcessComplete;
        MtEvents.onRestartMission += OnRestartMission;
    }

    private void OnDestroy() {
        MtEvents.onProcessComplete -= OnProcessComplete;
        MtEvents.onRestartMission -= OnRestartMission;
    }

    void Update() {
        if (Input.anyKey) waitKey = false;

    }


    private void OnTriggerEnter(Collider other) {
        if (Game.ins.missionCompleted[idMission] || (doingMission)) return;
        if (other.tag == "Player") {
            for (int i = 0; i < substancesNedeed.Length; i++) {
                if (substancesNedeed[i].gameObject.activeSelf) {
                    StartCoroutine(NotAllMaterials());
                    return;
                }
            }
            if (!initProgress) {
                initProgress = true;
                Game.ins.SubmitProgress();
            }
            Game.ins.mission = idMission;
            StartCoroutine(Mission());
            followCamera.Changefocus(focusEnum.talking);
            MtEvents.PlayerGoToPoint(posiObj);
        }
    }

    IEnumerator NotAllMaterials() {
        Game.ins.onPause = true;
        Game.ins.mission = idMission;
        Game.ins.statusGame = StatusGame.Talking;       
        followCamera.Changefocus(focusEnum.talking);
        Talk(true, "CheM", true);
        yield return new WaitForSeconds(3f);
        followCamera.Changefocus(focusMission);   
        textMsg.gameObject.SetActive(false);
        Game.ins.statusGame = StatusGame.Exploring;       
        Game.ins.onPause = false;
    }


    bool IsSubstanceCorrect(int i, int j) {
        if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.IsMust) return true;
        else if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.posibleCorrect) return true;
        else if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.posibleWrong) return true;
        else return false; 
    }


    void Talk(bool talkNPC, string lineTalk, bool talkFast = false) {
        Game.ins.soundTalk.Play();
        if (talkNPC) {
            if (fillTextCoroutine != null) StopCoroutine(fillTextCoroutine);
            fillTextCoroutine = FillingTextCor(Game.ins.GetText(lineTalk, true), talkFast);
            StartCoroutine(fillTextCoroutine);
            playerController.CloseMsg();
        } else {
            textMsg.gameObject.SetActive(false);
            playerController.ShowMsg(Game.ins.GetText(lineTalk, true));
        }
    }


    IEnumerator FillingTextCor(string msg, bool talkfast) {
        Game.ins.msgCompleted = false;
        textMsg.gameObject.SetActive(true);
        textMsg.text = "";
        for (int i = 0; i < msg.Length; i++) { 
            textMsg.text = textMsg.text + msg[i];
            // audio step
            yield return new WaitForSeconds(talkfast? 0.03f : 0.05f);            
        }
        Game.ins.msgCompleted = true;
    }



    bool SubstanceGenerated(bool noValue) {
        return true;
    }

    bool WaitForInputAndMessage() {
        if (!Game.ins.msgCompleted) return false;
        return WaitForInput();
    }
    bool WaitForInput() {
        if (Input.GetKeyUp(KeyCode.Space)) return true;
        if (Input.GetKeyUp(KeyCode.Return)) return true;
        if (Input.GetMouseButton(0)) return true;
        return false;
    }

    public void OnRestartMission() {
        if (doingMission) {
            StopAllCoroutines();
            doingMission = false;
            foreach (PickeableSubstance item in substancesNedeed) {
                item.gameObject.SetActive(true);
                item.Restart();
            }
            Game.ins.statusGame = StatusGame.Exploring;
            restartedMision = true;
            followCamera.Changefocus(focusMission);
            textMsg.gameObject.SetActive(false);
            Game.ins.onPause = false;
        }
    }

    IEnumerator Mission() {
       // Predicate<bool> SubstanceReady = SubstanceGenerated;
       // Predicate<bool> WaitforKey = WaitForInput;
        doingMission = true;
        Game.ins.onPause = true;
        int i = 0;
        bool doneStep = false;
        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => !playerController.goToPoint);
        while (i < mission.story[idMission].Length) {
            doneStep = false;
            if (mission.story[idMission][i].step == MissionStep.Talk) Game.ins.StarTalking();  
            if (mission.story[idMission][i].step == MissionStep.Mix) Game.ins.StartMixing();
            if (mission.story[idMission][i].step == MissionStep.Separate) Game.ins.StarSeparating();           
            yield return new WaitForSeconds(0.2f);
            ChangeFace(i);
            if (mission.story[idMission][i].step == MissionStep.Talk) {
                Talk(mission.story[idMission][i].talkNPC, mission.story[idMission][i].linetalk);  
                yield return new WaitUntil(() => WaitForInputAndMessage());
                textMsg.gameObject.SetActive(false);
                playerController.CloseMsg();
                doneStep = true;
            } else {
                MtEvents.ShowMessage(mission.story[idMission][i].linetalk);
                Game.ins.soundTalk.Play();           
            }
            if ((mission.story[idMission][i].step == MissionStep.Mix) || (mission.story[idMission][i].step == MissionStep.Separate)) {
                subsPutToInventory = false;              
                yield return new WaitUntil(() => subsPutToInventory);        
                doneStep = GotSubstanceMustOrPosible(i);
                yield return new WaitUntil(() => WaitForInputAndMessage());
                print("after substance got, showMsg key: " + msg);
                MtEvents.ShowMessage(msg);
                Game.ins.soundTalk.Play();
                yield return new WaitUntil(() => WaitForInputAndMessage());

                if (doneStep) {
                    print("Done step: " + doneStep);
                    Game.ins.StarTalking();   
                    yield return new WaitUntil(() => WaitForInputAndMessage());
                }
                //Check Inventory Required
                if (!IsAvilableInventaryRequired(i, mission.story[idMission][i].step) && !doneStep) {
//                    Talk(false, "CheBI");
                    MtEvents.ShowMessage("CheBI");  print("Message Chebi");
                    Game.ins.soundTalk.Play();
                    yield return new WaitUntil(() => WaitForInputAndMessage());
                    textMsg.gameObject.SetActive(false);
                    playerController.CloseMsg();
                    MtEvents.RestartMission();
                    MtEvents.PurgeInventory();
                }
            }
            if (doneStep) i++;
            yield return new WaitForEndOfFrame();       
        }
        doingMission = false;
        Game.ins.onPause = false;
        textMsg.gameObject.SetActive(false);
        playerController.CloseMsg();
        Game.ins.statusGame = StatusGame.Exploring;
        followCamera.Changefocus(focusMission);
        Game.ins.missionCompleted[idMission] = true;
        Game.ins.SubmitProgress();
        if (Game.ins.AllMissionCompleted()) {
            Game.ins.CompletedGame();
            //Game Completed
            //Game over
        }
    }    


    bool GotSubstanceMustOrPosible(int i) {
        switch (EvaluateSubstancesCompleted(i)) {
            case SubsNeededType.IsMust:
                print("Got Must msg:" + msgGet);
                msg = msgGet;
                Game.ins.soundSubstanceComplete.Play();
                MtEvents.AddPoints(3000);
            return true;
            case SubsNeededType.posibleCorrect:
                print("Got a possible msg:" + msgGet);
                msg = msgGet;
                MtEvents.AddPoints(3000);
                Game.ins.soundSubstanceComplete.Play();
            return true;
            case SubsNeededType.posibleWrong:
                print("Got a possible msg:" + msgGet);
                msg = msgGet;
                MtEvents.AddPoints(1000);
                Game.ins.soundFailedSubstance.Play();
            return true;
            case SubsNeededType.halfWay:
                print("Got a half way msg:" + msgHalf);
                msg = msgHalf;
                Game.ins.soundSubstanceComplete.Play();
            break;
            case SubsNeededType.youfailed:
                print("Got a possible msg:" + msgWrong);
                msg = msgWrong;
                Game.ins.soundFailedSubstance.Play();
            break;
        }
        return false;
    }



    void ChangeFace(int i) {
        if (mission.story[idMission][i].talkNPC) selectFace.ChangeFace(mission.story[idMission][i].face);
        else playerController.selectFace.ChangeFace(mission.story[idMission][i].face);
    }



    bool IsAvilableInventaryRequired(int i, MissionStep missionStep) {
        bool canBeCreated = false;
        int subsLenght = mission.story[idMission][i].substancesNeeded.Length;     
        print ("SubsLengh - 1 : " + (subsLenght - 1));   
        for (int j = 0; j < (subsLenght - 1); j++) {  //The last substance must be None
            if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.IsMust) {    
                if (IsRecipeAvailable(mission.story[idMission][i].substancesNeeded[j].subs, missionStep)) {
                    canBeCreated = true;
                }  else {
                    return false;   //A must cannot be created
                }
            }
            if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.posibleCorrect) {
                if (IsRecipeAvailable(mission.story[idMission][i].substancesNeeded[j].subs, missionStep)) {
                print("ITS POSIBLE to make a correct " + mission.story[idMission][i].substancesNeeded[j].subs.ToString());
                return true; 
                } 
            }    
            if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.posibleWrong) {
                if (IsRecipeAvailable(mission.story[idMission][i].substancesNeeded[j].subs, missionStep)) {
                print("ITS POSIBLE to make a wrong " + mission.story[idMission][i].substancesNeeded[j].subs.ToString());                
                return true;  
                }
            }    
        }
        return canBeCreated;
    }

    bool IsRecipeAvailable(SubstanceName subs, MissionStep missionStep) {
        if (missionStep == MissionStep.Mix) {
            return combineRecipes.AreRequiredInInventory(subs);
        } else if (missionStep == MissionStep.Separate) {
            //return unMixingRecipes.AreRequiredInInventory(subs);
            return true;
        }
        return false;
    }

    SubsNeededType EvaluateSubstancesCompleted(int i) {
        bool oneDone = false;
        int mustCount = 0, mustDone = 0;
        int subsLenght = mission.story[idMission][i].substancesNeeded.Length;
        msgGet = "";
        msgHalf = "";
        msgWrong = "";
        for (int j = 0; j < (subsLenght - 1); j++) {  //The last substance must be None
            if (Game.ins.IsInInventory(mission.story[idMission][i].substancesNeeded[j].subs)) {
                if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.IsMust) {       
                    print("Found Substance in Inv: " + mission.story[idMission][i].substancesNeeded[j].subs);
                    msgGet = mission.story[idMission][i].substancesNeeded[j].lineGetIt;
                    mustCount++;
                    mustDone++;
                } else if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.posibleCorrect) {
                    print("Found Substance in Inv: " + mission.story[idMission][i].substancesNeeded[j].subs);
                    msgGet = mission.story[idMission][i].substancesNeeded[j].lineGetIt;
                    return SubsNeededType.posibleCorrect;               
                } else if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.posibleWrong) {  
                    print("Found Substance in Inv: " + mission.story[idMission][i].substancesNeeded[j].subs);
                    msgGet = mission.story[idMission][i].substancesNeeded[j].lineGetIt;
                    return SubsNeededType.posibleWrong;
                } else if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.halfWay) {
                    print("Found Substance in Inv: " + mission.story[idMission][i].substancesNeeded[j].subs);
                    msgHalf = mission.story[idMission][i].substancesNeeded[j].lineGetIt;
                    oneDone = true;
                }
            } else {
                if (mission.story[idMission][i].substancesNeeded[j].subsType == SubsNeededType.IsMust) {   
                    mustCount++;
                }
            }
        }
        print("Not Found mustCount = " + mustCount + ", mustDone = " + mustDone + ", msgHalf = " + msgHalf + ", MsgGet = " + msgGet + ", onedone = " + oneDone);
        msgWrong = mission.story[idMission][i].substancesNeeded[(subsLenght - 1)].lineGetIt;
        if (msgHalf == "") msgHalf = msgGet; 
        if (mustCount > 0) {
            if (mustCount == mustDone) return SubsNeededType.IsMust;
            else if (mustDone > 0) return SubsNeededType.halfWay;
        } 
        if (oneDone) return SubsNeededType.halfWay;
        return SubsNeededType.youfailed;
    }


    private void OnProcessComplete() {
        subsPutToInventory = true;
    }


}
}

