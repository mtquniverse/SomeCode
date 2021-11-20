using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class PeopleMove : MonoBehaviour {

    Rigidbody peopleRb;
    Animator peopleAc;

    [SerializeField] Vector3[] pathPoints;
    [SerializeField] float velocity;

    [SerializeField] StylePath stylePath;

   // float veloLerp = 0;
    bool forward = true;
    int i = 0;

    void Start() {
        peopleAc = this.GetComponent<Animator>();
		peopleRb = this.GetComponent<Rigidbody>();
        StartCoroutine(FollowPath());
        StartCoroutine(CheckingDistance());
    }


    IEnumerator FollowPath() {
        while (true) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, pathPoints[i], (velocity * Time.deltaTime));
            ChangeStatus(StatusType.Walk);
            peopleAc.SetFloat("Velocity", (velocity));
            yield return new WaitForEndOfFrame();

        }
    }

    IEnumerator CheckingDistance() {
        while (true) {
            if (Vector3.Distance(peopleRb.transform.position, pathPoints[i])  < 3f) {
                if (stylePath == StylePath.BackToIni) {
                    i++;
                    if (i == pathPoints.Length) i = 0;
                }
                if (stylePath == StylePath.ReturnWay) {
                    if (forward) i++; else i--;
                    if (i == -1) {
                        i = 1;
                        forward = true;
                    }
                    if (i == pathPoints.Length) {
                        i = pathPoints.Length - 2;
                        forward = false;
                    }
                }    
                this.transform.LookAt(pathPoints[i]);            
            }
            yield return new WaitForSeconds(1f);
        }
    }



    void ChangeStatus(StatusType newStatus) {

    }



}

}