using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPerformanceCamera : MonoBehaviour {

    public GameObject player;

    public Camera targetCamera;

    public float speed = 1.0f;     //移動スピード。デフォルトは1.0f

    public ControlPoint[] points = new ControlPoint[4]; //コントロール点

    public float nextPhaseWaitTime;     //次のフェーズへ移行する時間。カメラが移動を終えた時点からカウントを開始する

    float time;                     //時間のカウンタ

    float phaseTimeCount;

	// Use this for initialization
	void Start () {
        time = 0;
        phaseTimeCount = 0;

        targetCamera.transform.position = points[0].transform.position;

        Vector3 vec = player.transform.position - targetCamera.transform.position;

        Quaternion qua = Quaternion.LookRotation(vec);

        targetCamera.transform.rotation = qua;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        time += Time.deltaTime * speed;

        if (time >= 1.0f)
        {
            phaseTimeCount += Time.deltaTime;

            if(phaseTimeCount >= nextPhaseWaitTime)
            {
                //次のフェーズへ移行
                GameSceneManager.SetGamePhase(GamePhase.PHASE_READY);
                Destroy(gameObject);
                return;
            }
        }

        targetCamera.transform.position = MyMath.Bezier(points[0].transform.position, points[1].transform.position,
            points[2].transform.position, points[3].transform.position,time);

        Vector3 vec = player.transform.position - targetCamera.transform.position;

        Quaternion qua = Quaternion.LookRotation(vec);

        targetCamera.transform.rotation = qua;
    }
}
