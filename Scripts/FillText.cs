using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SimpleJSON;
using LoLSDK;
using UnityEngine.UI;
using TMPro;

namespace MarcosQuijada.Chemibot {

public class FillText : MonoBehaviour
{

    public string textToLoad;

    public bool useTextMeshPro = true;
    

    void Start() {
        MtEvents.onUpdateLanguage += UpdateText;
        UpdateText();
    }

    private void OnDestroy() {
        MtEvents.onUpdateLanguage -= UpdateText;
    }

    void UpdateText() {
        if (useTextMeshPro) this.GetComponent<TMP_Text>().text = Game.ins.GetText(textToLoad);
        else this.GetComponent<Text>().text = Game.ins.GetText(textToLoad);
    }



}
}