using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour {
    public int playerNumber;    // プレイヤーの番号だよ
    public Text TimeText;       // 時間を表示するテキストだよ
    int time;

	// Use this for initialization
	void Start () {
        //ゲーム画面で使っていたタイムを取得する
        time = ResultWork.GetTime(playerNumber);            // 時間を受け取る
        TimeText.text = ResultWork.GetTimeString(time);     // 時間を文字列にするよ
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
