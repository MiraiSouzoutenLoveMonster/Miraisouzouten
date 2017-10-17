using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeManager : MonoBehaviour {

    public Text drawTimeText;
    public bool IsDraw;

    static float[] playerGoalTime;

    static float playTime = 0;
    static bool isCount = false;

	// Use this for initialization
	void Start () {
        playTime = 0;
        isCount = false;
        playerGoalTime = new float[2];
        playerGoalTime[0] = 0;
        playerGoalTime[1] = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(isCount)
        {
            playTime += Time.deltaTime;
        }
	}

    public static void SetIsCount(bool start)
    {
        isCount = start;
    }

    public static float GetPlayTime()
    {
        return playTime;
    }

    //プレイヤーがゴールした時に呼ぶ
    public static void SetGoalTime(int playerNum)
    {
        if(playerNum < 0 || playerNum > 1)
        {
            return;
        }

        playerGoalTime[playerNum] = playTime;
    }

    public static float GetPlayerGoalTime(int playerNum)
    {
        if (playerNum < 0 || playerNum > 1)
        {
            return -1;
        }

        return playerGoalTime[playerNum];
    }

    public static int VictoryOrDefeat()
    {
        if(playerGoalTime[0] > playerGoalTime[1])
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public static bool FindVictory(int playerNum)
    {
        if(playerNum < 0 || playerNum >= 2)
        {
            return false;
        }

        if(playerNum == 0)
        {
            if(playerGoalTime[playerNum] < playerGoalTime[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (playerGoalTime[playerNum] < playerGoalTime[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
