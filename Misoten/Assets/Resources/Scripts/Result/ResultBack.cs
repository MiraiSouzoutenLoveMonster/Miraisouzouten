using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultBack : MonoBehaviour {
    public int playerNumber;    // プレイヤーの番号だよ
    public Image image;         // 貼り付け先だよ
    public Sprite winSprite;    // 勝ったプレイヤーの画像
    public Sprite loseSprite;   // 負けたプレイヤーの画像

    // Use this for initialization
    void Start()
    {
        int playerTime1, playerTime2;           // プレイヤーのゴールの時間だよ
        playerTime1 = ResultWork.GetTime(0);    // ぶちこむよ
        playerTime2 = ResultWork.GetTime(1);    // こっちは2Pだよ

        // 勝敗のチェックするよ
        if (playerNumber == 0)
        {
            if (playerTime1 <= playerTime2)
            {
                image.sprite = winSprite;
            }
            else
            {
                image.sprite = loseSprite;
            }
        }
        else
        {
            if (playerTime1 <= playerTime2)
            {
                image.sprite = loseSprite;
            }
            else
            {
                image.sprite = winSprite;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
