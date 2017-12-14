using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAction : MonoBehaviour {

    PlayerController[] players;

    Transform[] initPlayerPosition; //回転開始時のプレイヤーの座標
    public GameObject[] target;   //回転軸の目標値

    public float targetRotationPower; //回転軸の補間の速度
    public float targetMovePower;     //移動の補間の速度

    public Camera[] actionCamera;         //演出用カメラ

    float[] time;

	// Use this for initialization
	void Start () {
        players = new PlayerController[2];
        time = new float[players.Length];
        initPlayerPosition = new Transform[time.Length];
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Action();
	}

    //実際の移動処理
    void Action()
    {
        //登録されているプレイヤーの移動処理を行う
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                time[i] += Time.deltaTime;
                if(time[i] >= 1.0f)
                {
                    time[i] = 1.0f;
                    players[i].SetPlayerStatus(PlayerState.FINISH);
                }

                float rotTime, moveTime;
                rotTime = time[i] * targetRotationPower;
                moveTime = time[i] * targetMovePower;

                if(rotTime >= 1.0f)
                {
                    rotTime = 1;
                }
                if(moveTime >= 1.0f)
                {
                    moveTime = 1;
                }
                int playerNum = players[i].GetPlayerNumber();
                players[i].transform.position = Vector3.Lerp(initPlayerPosition[i].position,target[playerNum].transform.position,moveTime);
                players[i].transform.rotation = Quaternion.Slerp(initPlayerPosition[i].rotation,target[playerNum].transform.rotation,rotTime);
            }
        }
    }

    //教会前の演出を始める
    void ActionStart(PlayerController p)
    {      
        p.SetPlayerStatus(PlayerState.GOALACTION);
        int playerNum = p.GetPlayerNumber();
        initPlayerPosition[playerNum] = p.transform;
        players[playerNum] = p;
        time[playerNum] = 0;
        actionCamera[playerNum].gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触した時にプレイヤーを登録する
        if(other.gameObject.tag == "Player")
        {
            PlayerController p = other.gameObject.GetComponent<PlayerController>();

            ActionStart(p);
        }
    }
}
