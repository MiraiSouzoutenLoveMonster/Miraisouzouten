using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPlayerImage : MonoBehaviour {

    public Image playerImage;
    public Sprite winnerSprite;//勝者用スプライト
    public Sprite defeatSprite;//敗者用スプライト

    public int playerNumber;//プレイヤーの番号。1Pは1、2Pは2を指定

    // Use this for initialization
    void Start () {
        //勝敗に応じてスプライトを変更する
        if (GameTimeManager.FindVictory(playerNumber))
        {
            playerImage.sprite = winnerSprite;
        }
        else
        {
            playerImage.sprite = defeatSprite;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
