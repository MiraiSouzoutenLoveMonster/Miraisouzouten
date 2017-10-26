using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

    bool isFinished;

	// Use this for initialization
	void Start () {
        isFinished = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //ゴールした時の処理
    void Goal(PlayerController player)
    {
        ResultWorks.SetTime(player.GetPlayerNumber(),);
        if (isFinished)
        {
            return;
        }
        //リザルト画面へ移行
        FadeManager.SetNextFade("Result");
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
