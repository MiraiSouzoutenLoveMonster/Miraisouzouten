using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public string name; //プレイヤーの名前
    public float voice; //声の大きさ
}

public class SaveDataManager : MonoBehaviour {

    public int usePlayer;      //表示するランキングの数

    static List<PlayerData> playerDataList;

    // Use this for initialization
    void Awake () {
        //ランキングを表示しない
		if(usePlayer <= 0)
        {
            return;
        }

        LoadPlayerData();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //プレイヤーのランキングデータを読み込む
    void LoadPlayerData()
    {
        string rank;
        for(int i = 0;i < usePlayer; i++)
        {
            PlayerData data;

            rank = "rank"+(i+1).ToString();
            string name = PlayerPrefs.GetString(rank);

            if(name == "")
            {
                name = "Player"+(i+1).ToString();
            }

            float voice = PlayerPrefs.GetFloat(rank,-1);

            if(voice == -1)
            {
                voice = 0.0f;
            }

            data.name = name;
            data.voice = voice;

            playerDataList.Add(data);
        }
    }

    //今回プレイしたデータがランキングに入るかどうかの処理
    static public void SavePlayerData(PlayerData data)
    {
        for(int i = 0; i < playerDataList.Count; i++)
        {
            //今回プレイしたデータがランキングに乗る場合はランキングを更新する
            if(playerDataList[i].voice <= data.voice)
            {
                playerDataList.Insert(i,data);
                playerDataList.RemoveAt(playerDataList.Count);

                break;
            }
        }

        //ランキングのセーブ
        for (int i = 0; i < playerDataList.Count; i++)
        {
            PlayerPrefs.SetString("rank"+(i+1).ToString(),playerDataList[i].name);
            PlayerPrefs.SetFloat("rank" + (i + 1).ToString(), playerDataList[i].voice);
        }
    }

    //プレイヤーのセーブデータを取得
    static List<PlayerData> GetSaveData()
    {
        return playerDataList;
    }
}
