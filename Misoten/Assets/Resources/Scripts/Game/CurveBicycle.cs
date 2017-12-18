using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBicycle : MonoBehaviour {
    public PlayerController player;              //プレイヤーのオブジェクト。目標地点の1番最初のものと同一オブジェクト
    Camera targetCamera = null;                           //プレイヤーについているカメラ。一人称視点の場合はプレイヤーが傾いて見えるように回転量を計算し加算する
    //public GameObject rPoint;

    float time;                     //カーブの割合。0～1の間の数値になる
    float rotTime;
    bool isCurve;

    public float curvePower;              //カーブの際スピードを緩める倍率
    public float initplayerSpeed;         //カーブに入ったときのプレイヤーの速度

    public int targetPlayerNumber;          //対象プレイヤーの番号を指定する

    //ベジェ曲線のポイント
    public GameObject point0;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;

    Quaternion[] quas;

    public float[] curveSpeed;

    int curveQuaMode;

    public CurveCamera curveCamera;

    public GameObject centerPoint;

    bool isRightCurve;

    // Use this for initialization
    void Start () {
        time = 0;
        rotTime = 0;
        isCurve = false;
        curveQuaMode = 0;
        quas = new Quaternion[2];
        quas[0] = point1.transform.rotation;
        quas[1] = point2.transform.rotation;
        initplayerSpeed = 270;

        curveCamera.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //trueが設定されている場合はカーブ処理を行う
        if(isCurve)
        {
            Curve();
        }

        
	}

    //現在の地点から次の地点への移動を線形補間で計算して代入する
    void Curve()
    {
        time += Time.deltaTime * ((initplayerSpeed)/399.0f); //時間を加算
        if (time >= 1.0f)
        {
            time = 1.0f;
        }

        //移動処理
        Vector3 newPos = Bezier(point0.transform.position
            , point1.transform.position
            , point2.transform.position
            , point3.transform.position,
            time);
        player.gameObject.transform.position = new Vector3(newPos.x,player.gameObject.transform.position.y, newPos.z);
        Quaternion oldRot;
        oldRot = targetCamera.transform.localRotation;
        switch (curveQuaMode)
        {
            case 0:
                rotTime += Time.deltaTime * curveSpeed[curveQuaMode] * (initplayerSpeed / 399.0f);
                if (rotTime >= 1.0f)
                {
                    rotTime = 1.0f;
                }

                player.gameObject.transform.rotation = Quaternion.Slerp(point0.transform.rotation,
                    point1.transform.rotation,rotTime);
                break;
            case 1:
                rotTime += Time.deltaTime * curveSpeed[curveQuaMode] * (initplayerSpeed / 399.0f);
                if (rotTime >= 1.0f)
                {
                    rotTime = 1.0f;
                }

                player.gameObject.transform.rotation = Quaternion.Slerp(point1.transform.rotation,
                    point2.transform.rotation, rotTime);
                break;
            case 2:
                rotTime += Time.deltaTime * curveSpeed[curveQuaMode] * (initplayerSpeed / 399.0f);
                if (rotTime >= 1.0f)
                {
                    rotTime = 1.0f;
                }

                player.gameObject.transform.rotation = Quaternion.Slerp(point2.transform.rotation,
                    point3.transform.rotation, rotTime);
                break;
        }
        //newRot = player.transform.rotation;
        //Quaternion subRot = oldRot - newRot;
        //targetCamera.transform.localRotation = oldRot;

        if (rotTime >= 1.0f)
        {
            rotTime = 0.0f;
            curveQuaMode++;
            //if(curveQuaMode > 2)
            //{
            //    isCurve = false;
            //    player.SetPlayerStatus(PlayerState.NORMAL);
            //}
        }

        if(time >= 1.0f)
        {
            isCurve = false;
            player.SetPlayerStatus(PlayerState.NORMAL);
            curveCamera.SetTargetPlayer(null);
            curveCamera.gameObject.SetActive(false);
            player.CameraActivate(true);
        }
    }

    Vector3 Bezier(Vector3 p0,Vector3 p1,Vector3 p2,Vector3 p3,float t)
    {
        Vector3 a = Vector3.Lerp(p0,p1,t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);

        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(d,e,t);
    }

    //カーブを開始する。強制的にカーブを始めてしまうので呼び出すタイミングに注意
    public void CurveStart()
    {
        isCurve = true;
        rotTime = 0;
        time = 0;
        curveQuaMode = 0;

        curveCamera.SetTargetPlayer(player.gameObject);
        //player.CameraActivate(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //該当するオブジェクトと接触したらカーブを開始する
            if (other.gameObject.GetComponent<PlayerController>().GetPlayerNumber() == targetPlayerNumber)
            {
                //中心点が設定されている場合はそれを基準に右折か左折かを決定

                if(isRightCurve)
                {
                    //point0.transform.position = new Vector3(point0.transform.position.x, point0.transform.position.y, -point0.transform.position.z);
                }

                CurveStart();
                //curveCamera.gameObject.SetActive(true);
                player.SetPlayerStatus(PlayerState.CURVE);
                //initplayerSpeed = player.GetPlayerSpeed()*3.5f;

                initplayerSpeed = player.GetPlayerSpeed();

                Debug.Log("InitSpeed："+initplayerSpeed);

                point0.transform.position = player.transform.position;
                point0.transform.rotation = player.transform.rotation;
                targetCamera = player.GetPlayerCamera();
            }
        }
    }

    
}
