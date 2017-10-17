using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSpeed : MonoBehaviour {

    public int playerNumber;

    public Text SpeedText;

	// Use this for initialization
	void Start () {
        if (playerNumber > 2 || playerNumber <= 0)
        {
            playerNumber = 1;
        }

        if(SpeedText == null)
        {
            return;
        }

        //ゲーム画面で計測したスピードを取得する
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
