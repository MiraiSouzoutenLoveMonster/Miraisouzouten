using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {
    public GameObject[] startImg = new GameObject[2];   // スタートのやつ
    public Image[] player1Light = new Image[3];         // 信号の光だよ
    public Image[] player2Light = new Image[3];         // 信号の光だよ
    public Color waitColor;                             // 待機の時の色だよ
    public Color startColor;                            // スタートする時の色だよ

    int time;                               // 時間だよ
    int target;                             // 光る対象だよ
    bool start;                             // 開始するタイミングだよ
    bool startEnd;                          // 開始したあとだよ


	// Use this for initialization
	void Start () {
        // 初期化するよ
        time = 0;
        target = 0;
        startEnd = false;   // まだ終わってないよ
    }

	// Update is called once per frame
	void Update () {
        // スタートが終わってないなら更新だよ
        if (startEnd == false)
        {
            time++; // 時間+するよ

            // 一秒すぎたから色変えるよ
            if (time > 60)
            {
                time = 0;   // 時間をリセットだよ

                // 信号チェックだよ
                if (target < 3)
                {
                    player1Light[target].color = waitColor;     // 色変わるよ
                    player2Light[target].color = waitColor;     // 色変わるよ
                    target++;                                   // 次のライトに変えるよ
                }
                // こっちは信号全部光ったあとだから一斉にスタート色に変えるよ
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        player1Light[i].color = startColor;        // 色変わるよ
                        player2Light[i].color = startColor;        // 色変わるよ
                    }
                    // スタート演出終わったよ
                    startEnd = true;

                    GameSceneManager.SetGamePhase(GamePhase.PHASE_GAME);
                }
            }
        }
        // 信号全部光ったよ
        else
        {
            time++;

            // 光ったあと少したったら消すよ
            if( time > 60 )
            {
                startImg[0].SetActive(false);
                startImg[1].SetActive(false);
                gameObject.SetActive(false);
            }
        }
	}


    public void SetStartActive(bool use)
    {
        startImg[0].SetActive(use);
        startImg[1].SetActive(use);
        gameObject.SetActive(use);
    }
}
