using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class SimpleRotator : MonoBehaviour {
 //   Vector3 rot;
    [SerializeField] float rangeX = 1, rangeY = 1, rangeZ = 1;
    [SerializeField] Vector3 rot;
    [SerializeField] bool rotateOnPause = true;

    Quaternion qRot;

    void Start() {
        qRot = Quaternion.Euler(rot);
    }

    void Update() {
        this.transform.Rotate(rot * Time.deltaTime);
    }
}

}
