using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

namespace MarcosQuijada.Chemibot {

public class TweenEffects : MonoBehaviour {
   
    Image image;
    [SerializeField] Vector3 scaleIni, posiIni;
    [SerializeField] float timeScaling = 1f;
    [SerializeField] float timeGoDir = 0.5f;    
    [SerializeField] float timeGoDir2 = 0.5f;
    [SerializeField] float scaleMult = 1.3f;
    [SerializeField] float distanceToMove = 1000;
    [SerializeField] Direction defaultdireccion = 0;
    [SerializeField] animType animDefault = animType.goDirec; 
    [SerializeField] bool startHiden = true;
    [SerializeField] bool useImage = false, isHidden = false;
    public enum animType {DisappearScale, goDirec, goDirectPunch, DisappearScalingPunching};
    Color colorIni;
    bool starting = true;



    private void Awake() {
    //    posiIni = this.transform.localPosition;
    }

    IEnumerator Start() {
        scaleIni = this.transform.localScale;
        posiIni = this.transform.localPosition;
        float auxTimeScaling = timeScaling;
        float auxTimeGoDir = timeGoDir;
        float auxTimeGoDir2 = timeGoDir2;
        timeScaling = 0;
        timeGoDir = 0;
        timeGoDir2 = 0;
        if (useImage) image = this.GetComponent<Image>();
        if (image == null) useImage = false; 
        if (startHiden) {
            Hide();
        } 
        yield return new WaitForSeconds(1f);
        timeScaling = auxTimeScaling;
        timeGoDir = auxTimeGoDir;
        timeGoDir2 = auxTimeGoDir2;




        if (!startHiden) {
    //        Recover();
        }
        //        Invoke("SetPosiIni", 1f);
    }


    void InitHide() {
        if (animDefault == animType.DisappearScale) {
            DisappearScaling(true);
        } else if (animDefault == animType.goDirec) {
            GoDirection();
            //PutAway();
        } else if (animDefault == animType.goDirectPunch) {
            GoDirection();
            //PutAway();
        }
        isHidden = true;
    }

    public bool IsHidden() {
        return isHidden;
    }

    public void Hide() {
        if (animDefault == animType.DisappearScale) {
            DisappearScaling(true);
        } else if (animDefault == animType.goDirec) {
            GoDirection();
        } else if (animDefault == animType.goDirectPunch) {
            GoDirectionPunch();
        } else if (animDefault == animType.DisappearScalingPunching) {
            DisappearScalingPunching();
        }
        isHidden = true;
    }

    private void OnEnable() {

        if (starting) {
            starting = false;
            return;
        }
        Recover();
    }


    public void Recover()
    {

        if (animDefault != animType.DisappearScale)
        {
            transform.DOLocalMove(posiIni, timeGoDir);
        }
        if (useImage) image.DOFade(1, 1);
        this.transform.DOScale(scaleIni, timeGoDir);
        isHidden = false;
    }



    public void DisappearScaling(bool disappear) {
        if (disappear) {
            if (useImage) image.DOFade(0,1);
            this.transform.DOScale((scaleIni * scaleMult), timeScaling);
        } else {
            if (useImage) image.DOFade(1,1);
            this.transform.DOScale(scaleIni, 0.1f);
        };
        isHidden = true;
    }


    public void DisappearScalingPunching() {
        Sequence sequence;
        sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOPunchScale((scaleIni * scaleMult), 0.1f,1,0));
        sequence.Append(this.transform.DOScale(0, 0.5f));
        sequence.Play();
        isHidden = true;
    }





    public void GoDirectionPunch() { 
        GoInDirectionPunch((int) defaultdireccion); 
    }

    public void GoInDirectionPunch(int direc) {
        Sequence sequence;
        sequence = DOTween.Sequence();
        Direction dir = (Direction) direc;
        if (dir == Direction.left) {
            sequence.Append(transform.DOLocalMoveX(100,timeGoDir));       
            sequence.Append(transform.DOLocalMoveX(-distanceToMove,timeGoDir2));
        } else if (dir == Direction.right) {
            sequence.Append(transform.DOLocalMoveX(-100,timeGoDir));       
            sequence.Append(transform.DOLocalMoveX(distanceToMove,timeGoDir2));
        } else if (dir == Direction.up) {
            sequence.Append(transform.DOLocalMoveY(-100,timeGoDir));       
            sequence.Append(transform.DOLocalMoveY(distanceToMove,timeGoDir2));
        } else if (dir == Direction.down) {
            sequence.Append(transform.DOLocalMoveY(100,timeGoDir));       
            sequence.Append(transform.DOLocalMoveY(-distanceToMove,timeGoDir2));
        }
        sequence.Play();
        isHidden = true;
    }


    public void GoDirection() {
        GoInDirection((int) defaultdireccion, timeGoDir2);
    }
    public void GoDirectionTime(float timeGo) {
        GoInDirection((int) defaultdireccion, timeGo);
    }

    public void GoInDirection(int direc, float timeGo) {
        Sequence sequence;
        sequence = DOTween.Sequence();
        Direction dir = (Direction) direc;
        if (dir == Direction.left) {
            sequence.Append(transform.DOLocalMoveX(-distanceToMove,timeGo));
        } else if (dir == Direction.right) {
            sequence.Append(transform.DOLocalMoveX(distanceToMove,timeGo));
        } else if (dir == Direction.up) {
            sequence.Append(transform.DOLocalMoveY(distanceToMove,timeGo));
        } else if (dir == Direction.down) {
            sequence.Append(transform.DOLocalMoveY(-distanceToMove,timeGo));
        }
        sequence.Play();
        isHidden = true;
    }


}

}
