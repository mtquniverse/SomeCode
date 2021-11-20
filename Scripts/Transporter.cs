using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {
public class Transporter : MonoBehaviour {

    [SerializeField] Vector3 transportPoint;
    [SerializeField] Transform playerTr;
    [SerializeField] FollowCamera myCamera;
    [SerializeField] focusEnum focusCam;
    [SerializeField] AudioSource transportAudio;


    Vector3 offsetCamera;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            offsetCamera = myCamera.transform.position - playerTr.position;
            playerTr.position = transportPoint;
            myCamera.transform.position = offsetCamera + playerTr.position;
            myCamera.Changefocus(focusCam);
            Game.ins.soundTransport.Play();
            if (focusCam == focusEnum.inside) {
                Game.ins.musicExploring.Stop();
                Game.ins.musicInside.Play();
            } else {
                Game.ins.musicInside.Stop();
                Game.ins.musicExploring.Play();
            }
            Game.ins.Pause(0.5f);
        }
    }


}
}