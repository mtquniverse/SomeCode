using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MarcosQuijada.Chemibot {
public class DisableOnDistance : MonoBehaviour {

    [SerializeField] Transform transformToEvaluate;
    [SerializeField] GameObject[] objsToDisable;
    [SerializeField] float minimunValue = 3;

    float timeToCheck = 1f;
    void Start() {
    }


    private void Update() {
        timeToCheck -= Time.deltaTime;
        if (timeToCheck > 0) return;
        if (Vector3.SqrMagnitude(transformToEvaluate.position - this.transform.position) < minimunValue) {
            foreach (GameObject item in objsToDisable) {
                if (!item.activeSelf) item.SetActive(true);
            }
        } else {
            foreach (GameObject item in objsToDisable) {
                if (item.activeSelf) item.SetActive(false);
            }        
        }
        timeToCheck = 1;
    }




}
}
