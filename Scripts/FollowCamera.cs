using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class FollowCamera : MonoBehaviour
{

    [SerializeField] Transform followTr;
    [SerializeField] Vector3 closeFocus, rotationClose;
    [SerializeField] Vector3 offsetTr, rotationNormal, offsetInside, rotationInside;
    [SerializeField] Transform[] npcs;

    Quaternion rotClose, rotOffset, rotInside;
    public bool changing = false;
    Vector3 pointfocus;
    [SerializeField] float t;
    public focusEnum focus = focusEnum.outside; 

    void Start() {
        MtEvents.onLoadedStartData += OnLoadedStartData;
        rotOffset = Quaternion.Euler(rotationNormal);//this.transform.rotation;
        rotClose = Quaternion.Euler(rotationClose);
        rotInside = Quaternion.Euler(rotationInside); 
        Changefocus(focusEnum.outside);
        print(offsetTr.ToString());
    }

    private void OnDestroy() {
        MtEvents.onLoadedStartData -= OnLoadedStartData;        
    }


    void Update() {
        if (changing) return;
        if (focus == focusEnum.talking) {
            if (Game.ins.doingTutorial) {
                pointfocus = followTr.position;
            } else {    
                pointfocus = followTr.position + (npcs[Game.ins.mission].position - followTr.position) /2;        
            }
            this.transform.position = Vector3.Lerp(this.transform.position, pointfocus + closeFocus, (t * Time.deltaTime));
        } else if (focus == focusEnum.inside) {
            this.transform.position = Vector3.Lerp(this.transform.position, followTr.position + offsetInside, (t * Time.deltaTime));
        } else {
            this.transform.position = Vector3.Lerp(this.transform.position, followTr.position + offsetTr, (t * Time.deltaTime));
        }
    }


    void OnLoadedStartData() {
        this.transform.position = Game.ins.gameData.cameraPos;
        Changefocus(Game.ins.gameData.focusCam);
    }


    public void Changefocus(focusEnum _focus) {
        if (_focus == focusEnum.talking) StartCoroutine(ChangingCamera(closeFocus, rotClose, _focus));
        else if (_focus == focusEnum.inside) StartCoroutine(ChangingCamera(offsetInside, rotInside, _focus));
        else StartCoroutine(ChangingCamera(offsetTr, rotOffset, _focus));
    }

    IEnumerator ChangingCamera(Vector3 offset, Quaternion rot, focusEnum _focus) {
        float elapsepTime = 0, duration = 1f;
        focus = _focus;
        changing = true;
        while (elapsepTime < duration) {
            if (focus == focusEnum.talking) {
                if (Game.ins.doingTutorial) {
                    pointfocus = followTr.position;
                } else {    
                    pointfocus = followTr.position + (npcs[Game.ins.mission].position - followTr.position) /2;        
                }
                this.transform.position = Vector3.Lerp(this.transform.position, pointfocus + offset, (elapsepTime / duration));
            } else { 
                this.transform.position = Vector3.Lerp(this.transform.position, followTr.position + offset, (elapsepTime / duration));
            }
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rot, (elapsepTime / duration));
            elapsepTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        changing = false;

    }


}

}
