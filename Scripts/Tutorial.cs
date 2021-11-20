using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MarcosQuijada.Chemibot {

public class Tutorial : MonoBehaviour {

    [SerializeField] PlayerController playerController;
    [SerializeField] FollowCamera followCamera;

    [SerializeField] GameObject water, tea;
    [SerializeField] GameObject tutor1, tutor2, tutor3, restart1, restart2, miniMsg;

    [SerializeField] GameObject initColliders;

    bool subsPutToInventory = false;
    void Start() {
        MtEvents.onProcessComplete += OnProcessComplete;
        StartCoroutine("TutorialCor");
    }

    private void OnDestroy() {
        MtEvents.onProcessComplete -= OnProcessComplete;    
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


    IEnumerator TutorialCor() {   
        while (Game.ins.onPause) {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        if (Game.ins.tutorialDone) yield break;

        initColliders.SetActive(true);
        restart1.SetActive(false);
        restart2.SetActive(false);
        Game.ins.doingTutorial = true;
        Game.ins.onPause = true;
        Game.ins.StarTalking();  
        followCamera.Changefocus(focusEnum.talking);
        yield return new WaitForSeconds(1f);
        playerController.ShowMsg(Game.ins.GetText("Tutor1", true));
        yield return new WaitForSeconds(0.5f);
        miniMsg.SetActive(true);
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        miniMsg.SetActive(false);
        playerController.ShowMsg(Game.ins.GetText("Tutor2", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor3", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor4", true));
        yield return new WaitUntil(() => WaitForInputAndMessage()); 
        water.SetActive(true);
        tea.SetActive(true);
        playerController.ShowMsg(Game.ins.GetText("Tutor5", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.CloseMsg();
        Game.ins.statusGame = StatusGame.Exploring;
        followCamera.Changefocus(focusEnum.outside);
        Game.ins.onPause = false;
        yield return new WaitUntil(() => !tea.activeSelf && !water.activeSelf);    
        Game.ins.onPause = true;
        playerController.FaceCamera();
        Game.ins.StarTalking();  
        followCamera.Changefocus(focusEnum.talking);       
        StartCoroutine(TutorBlink(tutor1,2));
        playerController.ShowMsg(Game.ins.GetText("Tutor6", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor7", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());       
        playerController.ShowMsg(Game.ins.GetText("Tutor8", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        Game.ins.StartMixing();
        StartCoroutine(TutorBlink(tutor1,0,5));
        StartCoroutine(TutorBlink(tutor2,3));
        while (!(Game.ins.IsInInventory(SubstanceName.TeHerbsAndResidual) ||
        Game.ins.IsInInventory(SubstanceName.TeHerbsAndResidualFailed)) ) {
                MtEvents.ShowMessage("Tutor9");
                yield return new WaitUntil(() => WaitForInputAndMessage());    
                subsPutToInventory = false;
                yield return new WaitUntil(() => subsPutToInventory);                
        }
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        Game.ins.StarTalking();
        playerController.ShowMsg(Game.ins.GetText("Tutor10", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor11", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        Game.ins.StarSeparating();
        StartCoroutine(TutorBlink(tutor3,2));
        while (!(Game.ins.IsInInventory(SubstanceName.Te) ||
        Game.ins.IsInInventory(SubstanceName.TeFailed)) ) {
                MtEvents.ShowMessage("Tutor12");
                yield return new WaitUntil(() => WaitForInputAndMessage());    
                subsPutToInventory = false;
                yield return new WaitUntil(() => subsPutToInventory);                
        }
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        Game.ins.StarTalking();
        playerController.ShowMsg(Game.ins.GetText("Tutor13", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor14", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor15", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        playerController.ShowMsg(Game.ins.GetText("Tutor16", true));
        yield return new WaitUntil(() => WaitForInputAndMessage());    
        Game.ins.statusGame = StatusGame.Exploring;
        initColliders.SetActive(false);
        followCamera.Changefocus(focusEnum.outside);
        restart1.SetActive(true);
        restart2.SetActive(true);
        playerController.CloseMsg();
        Game.ins.onPause = false;
        Game.ins.doingTutorial = false;
        Game.ins.tutorialDone = true;
        initColliders.SetActive(false);
    }




    private void OnProcessComplete() {
        subsPutToInventory = true;
    }



    IEnumerator TutorBlink(GameObject tutor, float wait = 0, int numBlink = 10) {
        if (wait > 0) yield return new WaitForSeconds(wait);
        for (int i = 0; i < numBlink; i++) {
            tutor.SetActive(!tutor.activeSelf);
            yield return new WaitForSeconds(0.4f);
        }
        tutor.SetActive(false);
    }

}
}

