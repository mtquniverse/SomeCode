using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MarcosQuijada.Chemibot {
public class PointsCont : MonoBehaviour {

    int actualPoints = 0;
    [SerializeField] TMP_Text pointsTxt; 
    [SerializeField] GameObject particlePoints;


    void Start() {
        MtEvents.onPickupSubstance += OnPickupSubstance;
        MtEvents.onAddPoints += OnAddPoints;
        MtEvents.onPickupStar += OnPickupStar;
        MtEvents.onLoadedStartData += OnLoadedStartData;
    }

    private void OnDestroy() {
        MtEvents.onPickupSubstance -= OnPickupSubstance;
        MtEvents.onAddPoints -= OnAddPoints;    
        MtEvents.onPickupStar -= OnPickupStar;
        MtEvents.onLoadedStartData -= OnLoadedStartData;
    }


    void OnLoadedStartData() {
        Game.points = Game.ins.gameData.points;
        StartCoroutine(UpdatePointsTxt());   
    }

    void OnPickupSubstance(SubstanceName subs, Vector3 posi) {
        Game.points += 1000;
        StartCoroutine(UpdatePointsTxt());
    }

    void OnPickupStar(Vector3 posi) {
        Game.points += 500;
        StartCoroutine(UpdatePointsTxt());
    }

    void OnAddPoints(int points) {
        Game.points += points;
        StartCoroutine(UpdatePointsTxt());    
    }

    IEnumerator UpdatePointsTxt() {
        particlePoints.SetActive(true);
        while (actualPoints < Game.points) {
            pointsTxt.text = actualPoints.ToString();
            actualPoints += 98;
            yield return new WaitForSeconds(0.05f);
        }
        actualPoints = Game.points;
        pointsTxt.text = actualPoints.ToString();
        yield return new WaitForSeconds(1f);
        particlePoints.SetActive(false);
    }

}

}