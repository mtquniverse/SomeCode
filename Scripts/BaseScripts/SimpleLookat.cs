using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class SimpleLookat : MonoBehaviour {
    public Transform target;

    void Update() {
        this.transform.LookAt(target);
    }
}

}
