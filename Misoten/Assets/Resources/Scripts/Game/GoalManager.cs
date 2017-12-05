using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour {
    int goalPlayerNum;  // 俺いじってないやつ

    public Sprite goalSprite;                   // ゴールの画像だよ
    public Image[] goalImage = new Image[2];    // ゴールの表示領域だよ
    public Vector3 maxScale;                    // スケールの最大値だよ
    public int addTime;                         // 加算に使う時間だよ
    public string goalSeName;
    public string toResultSeName;
    int[] time = new int[2];                    // 加算した時間だよ
    Vector3 addScale;                           // 加算するスケールの値だよ
    public PlayerController[] players;

	// Use this for initialization
	void Start () {
        // 加算するスケールの値を計算するよ
        addScale = maxScale / addTime;

        for (int i = 0; i < 2; i++)
        {
            time[i] = 0;
        }
        //goalImage[0].sprite = goalSprite;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            goalImage[1].sprite = goalSprite;
        }

        // ゴールしたら画像が貼ってあるよ
        for (int i = 0; i < 2; i++)
        {
            // 画像あるかチェックだよ
            if (goalImage[i].sprite != null)
            {
                // 画像あるから時間加算するよ
                time[i]++;
                // 加算の時間より小さいかチェックだよ
                if (time[i] < addTime)
                {
                    // スケールに加算するよ
                    goalImage[i].rectTransform.localScale += addScale;
                }
            }
        }

        //全プレイヤーが教会前についたらリザルトへ
        if (players[0].GetPlayerState() == PlayerState.FINISH && players[1].GetPlayerState() == PlayerState.FINISH)
        {
            //ここでゲーム終了を設定し、その後演出とリザルト画面への遷移を実行
            GameSceneManager.SetGamePhase(GamePhase.PHASE_FINISH);
            //リザルト画面へ移行
            MultiFadeManager.SetNextFade("Result");
            SoundManager.PlaySE(toResultSeName);
        }
    }

    //ゴールした時の処理
    void Goal(PlayerController player)
    {
        int playerNumber = player.GetPlayerNumber();
        ResultWork.SetTime(playerNumber, (int)GameTimeManager.GetPlayerGoalTime(playerNumber));

        // ゴールのspriteを貼り付けるよ
        goalImage[playerNumber].sprite = goalSprite;

        goalPlayerNum++;

        player.SetPlayerStatus(PlayerState.GOAL);

        //ゴールした時の音を鳴らす
        SoundManager.PlaySE(goalSeName);
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
