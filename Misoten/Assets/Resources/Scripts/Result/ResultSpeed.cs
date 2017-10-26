using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSpeed : MonoBehaviour {
    public int playerNumber;        // プレイヤーの番号だよ
    public Text SpeedText;          // 速度を表示するテキストだよ
    float speed;                    // 速度だよ

	// Use this for initialization
	void Start () {
        //ゲーム画面で使っていたタイムを取得する
        speed = (int)ResultWork.GetMaxSpeed(playerNumber);
        string str = "";                    // 文字列だよー
        str += ((int)speed).ToString();     // 速度を文字列にするよ
        str += "km/h";

        // 入れるよー
        SpeedText.text = str;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
