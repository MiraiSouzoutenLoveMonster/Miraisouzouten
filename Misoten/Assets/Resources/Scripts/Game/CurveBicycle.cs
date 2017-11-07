using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBicycle : MonoBehaviour {
    public PlayerController player;              //プレイヤーのオブジェクト。目標地点の1番最初のものと同一オブジェクト

    //public GameObject rPoint;

    float time;                     //カーブの割合。0～1の間の数値になる
    float rotTime;
    bool isCurve;

    public float curvePower;              //カーブの際スピードを緩める倍率
    public float initplayerSpeed;         //カーブに入ったときのプレイヤーの速度

    //ベジェ曲線のポイント
    public GameObject point0;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;

    Quaternion[] quas;

    public float[] curveSpeed;

    int curveQuaMode;

    public CurveCamera curveCamera;

    // Use this for initialization
    void Start () {
        time = 0;
        rotTime = 0;
        isCurve = false;
        curveQuaMode = 0;
        quas = new Quaternion[2];
        quas[0] = point1.transform.rotation;
        quas[1] = point2.transform.rotation;
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
        time += Time.deltaTime * (initplayerSpeed/399.0f); //時間を加算

        if(time >= 1.0f)
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
        player.CameraActivate(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //該当するオブジェクトと接触したらカーブを開始する
        if(other.gameObject == player.gameObject)
        {
            CurveStart();
            player.SetPlayerStatus(PlayerState.CURVE);

            initplayerSpeed = player.GetPlayerSpeed();

            point0.transform.position = player.transform.position;
            point0.transform.rotation = player.transform.rotation;
        }
    }

    
}
