using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

    int goalPlayerNum;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //ゴールした時の処理
    void Goal(PlayerController player)
    {
        int playerNumber = player.GetPlayerNumber();
        ResultWork.SetTime(playerNumber, (int)GameTimeManager.GetPlayerGoalTime(playerNumber));

        goalPlayerNum++;

        if(goalPlayerNum >= 2)
        {
            //リザルト画面へ移行
            FadeManager.SetNextFade("Result");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触したらゴールしたとみなしゴール後の処理を行う
        if(other.gameObject.tag == "Player")
        {
            //ゴール処理
            Goal(other.GetComponent<PlayerController>());
        }
    }
}
