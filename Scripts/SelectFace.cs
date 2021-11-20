using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class SelectFace : MonoBehaviour {

    Material material;
    MeshRenderer mesh;
    SkinnedMeshRenderer meshSkinned;
    [SerializeField] float[] offsetX, offsetY;
    [SerializeField] int matNumber;

    [SerializeField] FacesType faceActual;

    void Start() {
        mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
            material = mesh.materials[matNumber];
        else {
            meshSkinned = GetComponent<SkinnedMeshRenderer>();
            material = meshSkinned.materials[matNumber];
        }
        ChangeFace(faceActual);
    }

    IEnumerator ChangeFaces() {
        while (true) {
            for (int i = 0; i < offsetX.Length; i++) {
                ChangeFace((FacesType) i);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public void ChangeFace(FacesType face) {
        faceActual = face;
        material.SetTextureOffset("_MainTex", new Vector2(offsetX[(int)face], offsetY[(int)face]));    
    }


}

}