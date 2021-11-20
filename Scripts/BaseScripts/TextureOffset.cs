using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class TextureOffset : MonoBehaviour
{

    float offsetX = 0, offsetY = 0;
    public float veloX = 0, veloY = 0;
    Material material;
    MeshRenderer mesh;
    SkinnedMeshRenderer meshSkinned;
    bool onPausePause = true;


    void Start() {
        mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
            material = mesh.material;
        else {
            meshSkinned = GetComponent<SkinnedMeshRenderer>();
            material = meshSkinned.material;
        }
    }

    // Update is called once per frame
    void Update() {
        if (onPausePause && Game.ins.onPause) return;
   //     offsetX += (veloX * GameController.ins.velocity) * Time.deltaTime;
   //     offsetY += (veloY * GameController.ins.velocity) * Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}

}
