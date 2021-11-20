using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MarcosQuijada.Chemibot {

public class PlayerController : MonoBehaviour {
    Rigidbody playerRb;
	Animator playerAc;
    [SerializeField] TMP_Text textMsg;
    public SelectFace selectFace;


    enum MoveDirection { Up = 0, RightUp = 45, Right = 90, RightDown = 135, Down = 180, LeftDown = 225, Left = 270, LeftUp = 315, none = 999};

    [SerializeField] float velocity;
    float toRotate = 0, veloLerp = 0, myInpHor = 0, myInpVer = 0;

    MoveDirection moveDir, moveDirHor, moveDirVer;

    Vector3 posiObj, difference;
    public bool goToPoint {get;set;} = false;

    private IEnumerator fillTextCoroutine;

    void Start() {
		playerAc = this.GetComponent<Animator>();
		playerRb = this.GetComponent<Rigidbody>();
        MtEvents.onPlayerGoToPoint += OnPlayerGoToPoint;
        MtEvents.onLoadedStartData += OnLoadedStartData;        
    }

    private void OnDestroy() {
        MtEvents.onPlayerGoToPoint -= OnPlayerGoToPoint;
        MtEvents.onLoadedStartData -= OnLoadedStartData;        
    }

    void OnLoadedStartData() {
        this.transform.position = Game.ins.gameData.playerPos;
    }

    void Update() {
        GetInput();

    }


    private void FixedUpdate() {
        if ((Game.ins.onPause) && (!goToPoint)) {
            veloLerp = 0;
            playerAc.SetFloat("Velocity", 0);
            if (Game.ins.soundRunning.isPlaying) Game.ins.soundRunning.Stop();
            return;
        }
        if (!goToPoint) {
            myInpHor =  Input.GetAxis("Horizontal");
            myInpVer = Input.GetAxis("Vertical");
        }
        if (moveDir != MoveDirection.none) {
            playerRb.MoveRotation(Quaternion.Lerp(playerRb.rotation,  Quaternion.Euler(0,(float) moveDir,0), 0.2f ));
            playerRb.AddRelativeForce(new Vector3(0,0,1),ForceMode.Acceleration);
            veloLerp = Mathf.Lerp(veloLerp, velocity, 0.1f);
            playerAc.SetFloat("Velocity", (veloLerp/velocity));
    		playerRb.position = new Vector3(playerRb.position.x + (velocity * myInpHor * Time.deltaTime), 
    		playerRb.position.y, playerRb.position.z + (velocity * myInpVer * Time.deltaTime));
            toRotate = (int) moveDir;
            if (!Game.ins.soundRunning.isPlaying) Game.ins.soundRunning.Play();
        } else {
            veloLerp = Mathf.Lerp(veloLerp, 0, 0.1f);
            playerAc.SetFloat("Velocity", (veloLerp/velocity));
            if (Game.ins.soundRunning.isPlaying) Game.ins.soundRunning.Stop();
        }
    }

    void GetInput() {
        moveDir = MoveDirection.none;
        moveDirHor = MoveDirection.none;
        moveDirVer = MoveDirection.none;
        if (goToPoint) {
            CalculateDirection();
        } else {
            GetDirectionInput();
        }
        if (moveDirVer == MoveDirection.Up) {
            if (moveDirHor == MoveDirection.Left) moveDir = MoveDirection.LeftUp;
            else if (moveDirHor == MoveDirection.Right) moveDir = MoveDirection.RightUp;
            else moveDir = MoveDirection.Up;           
        } else if (moveDirVer == MoveDirection.Down) {
            if (moveDirHor == MoveDirection.Left) moveDir = MoveDirection.LeftDown;
            else if (moveDirHor == MoveDirection.Right) moveDir = MoveDirection.RightDown;
            else moveDir = MoveDirection.Down;                   
        } else {
            if (moveDirHor == MoveDirection.Left) moveDir = MoveDirection.Left;
            else if (moveDirHor == MoveDirection.Right) moveDir = MoveDirection.Right;
        }
        Game.ins.moving = (moveDir == MoveDirection.none)? false : true;  
    }

    void GetDirectionInput() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            moveDirVer = MoveDirection.Up;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            moveDirVer = MoveDirection.Down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            moveDirHor = MoveDirection.Left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveDirHor = MoveDirection.Right;
        }
    }

    void CalculateDirection() {
        myInpHor = 0f;
        myInpVer = 0f;
        difference = this.transform.position - posiObj;
        if (Mathf.Abs(difference.x) > 0.1f) {
            if (this.transform.position.x - posiObj.x < 0) {
                moveDirHor =  MoveDirection.Right;
                myInpHor = 0.7f;
            } else {
                myInpHor = -0.7f;
                moveDirHor = MoveDirection.Left;
            }       
        } 
        if (Mathf.Abs(difference.z) > 0.1f) {
            if (this.transform.position.z - posiObj.z < 0) {
                myInpVer = 0.7f;
                moveDirVer =  MoveDirection.Up;
            } else {
                myInpVer = -0.7f; 
                moveDirVer =  MoveDirection.Down;
            }
        }
        if ((moveDirHor == MoveDirection.none) && (moveDirVer == MoveDirection.none)) {
            goToPoint = false;
            StartCoroutine(FaceThePlayer());
        }
    }

    public void FaceCamera() {
        StartCoroutine(FaceThePlayer());
    }
    IEnumerator FaceThePlayer() {
        float elapsepTime = 0;
        while (elapsepTime < 1) {
            playerRb.MoveRotation(Quaternion.Lerp(playerRb.rotation,  Quaternion.Euler(0,(float) -170f,0), 0.2f ));
            elapsepTime += Time.deltaTime;
            yield return null;
        }
    }


    public void OnPlayerGoToPoint(Vector3 posi) {
        goToPoint = true;
        posiObj = posi;
    }


    public void ShowMsg(string msg) {
        if (fillTextCoroutine != null) StopCoroutine(fillTextCoroutine);
        fillTextCoroutine = FillingTextCor(msg);
        StartCoroutine(fillTextCoroutine);
    }

    public void CloseMsg() {
        textMsg.gameObject.SetActive(false);
    }



    IEnumerator FillingTextCor(string msg) {
        Game.ins.msgCompleted = false;
        textMsg.gameObject.SetActive(true);
        textMsg.text = "";
        for (int i = 0; i < msg.Length; i++) { 
            textMsg.text = textMsg.text + msg[i];
            // audio step
            yield return new WaitForSeconds(0.05f);            
        }
        Game.ins.msgCompleted = true;
    }



}

}