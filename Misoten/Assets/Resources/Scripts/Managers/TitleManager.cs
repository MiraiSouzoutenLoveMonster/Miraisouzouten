using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TitleManager : MonoBehaviour {

    public string nextScene = "Game";

    bool[] isTrigger;
    int initConnectedAndroid;

    public string bgmName;
    public string toGameSeName;

    // Use this for initialization
    void Start () {
        SoundManager.StopBGM();
        SoundManager.PlayBGM(bgmName);
        initConnectedAndroid = AndroidInputManager.GetConnectInputCount();
        if(initConnectedAndroid != 0)
        {
            isTrigger = new bool[initConnectedAndroid];
        }     
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.PlaySE(toGameSeName);
            MultiFadeManager.SetNextFade(nextScene,0);
        }
        
        int connectedAndroid = AndroidInputManager.GetConnectInputCount();//現在接続されている数を取得する

        if(connectedAndroid == 0)
        {
            return;
        }

        //前フレームと現在で接続数が違う場合はトリガー判定の配列を再確保する
        if(initConnectedAndroid != connectedAndroid)
        {
            isTrigger = new bool[connectedAndroid];
        }

        //対応するアンドロイドのボタンが押されているかを判定
        for(int i = 0; i < connectedAndroid; i++)
        {
            if(AndroidInputManager.GetAndroidInput(i).GetDown())
            {
                isTrigger[i] = true;
            }
        }

        //全てのアンドロイドがボタンを押したか判定
        for (int i = 0; i < connectedAndroid; i++)
        {
            //押している場合は何もしない
            if(!isTrigger[i])
            {
                return;
            }
        }

        //全て押しているならゲームシーンへ移行
        SoundManager.PlaySE(toGameSeName);
        MultiFadeManager.SetNextFade(nextScene, 0);

    }
}
