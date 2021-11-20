using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MarcosQuijada.Chemibot {

public class SimpleFloat : MonoBehaviour
{
    Vector3 posiIni, rotIni;
    public float intensity;
 
    void Start()
    {
        posiIni = this.transform.localPosition;
        rotIni = this.transform.rotation.eulerAngles;
        StartCoroutine(Float());
    }

    IEnumerator Float() {
        float sec = Random.Range(5f, 10f);
        while (true) {
            sec = Random.Range(5f, 10f);
         //   this.transform.DOLocalMove(posiIni + new Vector3(Random.Range(-intensity,intensity),Random.Range(-intensity,intensity),Random.Range(-intensity,intensity)),sec);
            yield return new WaitForSeconds(sec);
        }
    }


}
}
