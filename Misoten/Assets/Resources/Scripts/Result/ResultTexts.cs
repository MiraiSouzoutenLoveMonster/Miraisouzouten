using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTexts : MonoBehaviour {

    public Text[] texts;

    List<PlayerData> playerData;

	// Use this for initialization
	void Start () {
        playerData = SaveDataManager.GetSaveData();

        for(int i = 0; i < texts.Length; i++)
        {
            float floatingTime = playerData[i].time % 1;

            texts[i].text = i.ToString() + "位 " + 
                ((int)playerData[i].time).ToString() + 
                ":" + floatingTime.ToString("f2");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
