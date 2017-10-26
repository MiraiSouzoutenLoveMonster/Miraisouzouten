using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultWork : MonoBehaviour {
    public int playerNum;                   // プレイヤー人数だよ
    public int rankingNum = 5;              // ランキングの数だよ

    static public int playerMax;            // プレイヤー人数入れるよ
    static private int[] clearTime;         // クリアした時間だよ
    static private float[] maxSpeed;        // 最大速度だよ
    static private List<int> rankingList;   // ランキングのリストだよ
    static private int[] rank;              // ランクのリストだよ

    private void Awake()
    {
        // 破棄を無効化
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        playerMax = playerNum;                  // プレイヤー人数
        // 確保するよ プレイヤー人数分だよ
        clearTime = new int[playerNum];         // タイムだよ
        maxSpeed = new float[playerNum];        // 最大速度
        rankingList = new List<int>();          // ランキング数
        rank = new int[playerNum];              // プレイヤー事のランキングだよ

        // ランキングのリストに5個、遅いクリア時間をぶっこむよ
        for (int i = 0; i < rankingNum; i++)
        {
            rankingList.Add(240 + i*30+ i + 2);
        }

        // 初期化するよ
        Init();
    }


    // 初期化だよ
    static public void Init () {
        for (int i = 0; i < playerMax; i++)
        {
            clearTime[i] = 0;
            maxSpeed[i] = 0;
            rank[i] = 5;
        }
    }


    // 時間をセットするよ
    static public void SetTime(int i, int time)
    {
        clearTime[i] = time;
        SetRanking(i,time);
    }
    // 最大速度を更新するよ
    static public void SetMaxSpeed(int i, float speed)
    {
        if (maxSpeed[i] <= speed)
        {
            maxSpeed[i] = speed;
        }
    }
    // ランキングのセット＆ソートだよ
    static public void SetRanking(int i, int time )
    {
        rankingList.Add(time);                          // リストに追加するよ
        rankingList.Sort();                             // 追加したものもソートするよ
        rank[i] = rankingList.IndexOf(time);            // 自分の順位を探すよ 0 ~ 5になるって5はランキング外だよ
        rankingList.RemoveAt(rankingList.Count - 1);    // 1個要素を削除するよ
    }


    // プレイヤーのランクだよ
    static public int GetRank(int i)
    {
        return rank[i];
    }
    // タイム受け取るよ
    static public int GetTime(int i)
    {
        return clearTime[i];
    }
    // 最大速度受け取るよ
    static public float GetMaxSpeed(int i)
    {
        return maxSpeed[i];
    }
    // ランキングを受け取るよ
    static public List<int> GetRanking()
    {
        return rankingList;
    }
    // 時間を string にして受け取るよ
    static public string GetTimeString(int time)
    {
        string str = "";
        str += ((int)(time / 600)).ToString();       // 割るよ！
        str += ((int)(time / 60)).ToString();        // 割るよ！
        str += ":";
        time %= 60;                                  // 残りの時間だよ！
        str += ((time / 10)).ToString();             // あまり割るよ！
        str += ((time % 10)).ToString();             // あまり割るよ！
        return str;
    }
}
