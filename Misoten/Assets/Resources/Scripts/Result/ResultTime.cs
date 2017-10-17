using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour {

    public int playerNumber;

    public Text TimeText;

    float time;

	// Use this for initialization
	void Start () {
		if(playerNumber > 2 || playerNumber <= 0)
        {
            playerNumber = 1;
        }

        if(TimeText == null)
        {
            return;
        }

        //ゲーム画面で使っていたタイムを取得する
        //インデックスでプレイヤーを判断
        //time = GameTimeManager.GetPlayTime();
        time = 65.256f;//デバッグ用
        float floatingTime = time % 1;
        TimeText.text = ((int)time).ToString() + ":" + (floatingTime.ToString("f2")).Substring(2);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
