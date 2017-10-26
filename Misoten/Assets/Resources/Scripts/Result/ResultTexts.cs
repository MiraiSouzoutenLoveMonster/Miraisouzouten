using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTexts : MonoBehaviour {
    public int playerNumber;                            // プレイヤーの番号だよ
    public Text[] text;                                 // 順位の表示するやつだよ
    public Color flashingColor = new Color(0,0,0,255);  // 点滅色
    public int flashingFrameTime;                       // 点滅する時間

    List<int> rankingList;              // ランキングのリストだよ
    int rank;                           // 自分のランクだよ
    Color objectiveColor;               // 目標への色
    int time;                           // 時間だよ


    // Use this for initialization
    void Start()
    {
        time = 0;                                   // 初期化だよ
        rankingList = ResultWork.GetRanking();      // ランキングのリストもってくるよ
        rank = ResultWork.GetRank(playerNumber);    // プレイヤーのランクをもってくるよ
        string str;                                 // 文字列だよ

        // 1~5位のランキングを表示する
        for (int i = 0; i < rankingList.Count; i++)
        {
            str = "";
            str += ResultWork.GetTimeString(rankingList[i]);
            text[i].text = str;
        }

        // ランク内なら色点滅のためデフォの色を覚える
        if (rank < rankingList.Count)
        {
            objectiveColor = text[rank].color - flashingColor;  // 初期色 - 点滅後の色
            objectiveColor /= flashingFrameTime;                // できたの時間で割る
            objectiveColor *= -1.0f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        // ランキング内なら
        if (rank < rankingList.Count)
        {
            time++;

            // 指定した点滅時間すぎたら
            if (time > flashingFrameTime)
            {
                objectiveColor *= -1.0f;
                time = 0;
            }
            text[rank].color += objectiveColor;
        }
	}
}
