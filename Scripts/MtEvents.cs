using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MarcosQuijada.Chemibot {

public class MtEvents {


    public static event Action<SubstanceName, Vector3> onPickupSubstance;
    public static void PickupSubstance(SubstanceName substanceName, Vector3 posi) {
        if (onPickupSubstance != null) onPickupSubstance(substanceName, posi);
    }


    public static event Action<Vector3> onPickupStar;
    public static void PickupStar(Vector3 posi) {
        if (onPickupStar != null) onPickupStar(posi);
    } 


    public static event Action onUpdateLanguage;
    public static void UpdateLanguaje() {
        if (onUpdateLanguage != null) onUpdateLanguage();
    }


    public static event Action<bool> onUpdateSubstancesSelected;
    public static void UpdateSubstancesSelected(bool isAProcess = false) {
        if (onUpdateSubstancesSelected != null) onUpdateSubstancesSelected(isAProcess);
    }


    public static event Action<SubstanceName> onRemoveFromInventory;
    public static void RemoveFromInventory(SubstanceName subs) {
        if (onRemoveFromInventory != null) onRemoveFromInventory(subs);
    }

    public static event Action<SubstanceName> onPutToInventory;
    public static void PutToInventory(SubstanceName subs) {
        if (onPutToInventory != null) onPutToInventory(subs);
    }

    public static event Action<SubstanceName> onSelectInInventory;
    public static void SelectInInventory(SubstanceName subs) {
        if (onSelectInInventory != null) onSelectInInventory(subs);
    }

    public static event Action onChangeStatusGame;
    public static void ChangeStatusGame() {
        if (onChangeStatusGame != null) onChangeStatusGame();
    }

    public static event Action onDeselectAllInInventory;
    public static void DeselectAllInInventory() {
        if (onDeselectAllInInventory != null) onDeselectAllInInventory();
    }

    public static event Action onProcessComplete;
    public static void ProcessComplete() {
        if (onProcessComplete != null) onProcessComplete();
    }


    public static event Action<Vector3> onPlayerGoToPoint;
    public static void PlayerGoToPoint(Vector3 posi) {
        if (onPlayerGoToPoint != null) onPlayerGoToPoint(posi);
    }


    public static event Action onRestartMission;
    public static void RestartMission() {
        if (onRestartMission != null) onRestartMission();
    }

    public static event Action onPurgeInventory;
    public static void PurgeInventory() {
        if (onPurgeInventory != null) onPurgeInventory();
    }


    public static event Action onShowInventory;
    public static void ShowInventory() {
        if (onShowInventory != null) onShowInventory();
    }

    public static event Action<String, bool> onShowMessage;
    public static void ShowMessage(string lineTalk, bool talkFast = false) {
        if (onShowMessage != null) onShowMessage(lineTalk, talkFast);
    }


    public static event Action<int> onAddPoints;
    public static void AddPoints(int points) {
        if (onAddPoints != null) onAddPoints(points);
    }


    public static event Action onLoadedStartData;
    public static void LoadedStartData() {
        if (onLoadedStartData != null) onLoadedStartData();
    }

}

}