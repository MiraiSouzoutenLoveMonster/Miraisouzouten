using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする

public class ResultManager : MonoBehaviour {
    public string nextScene = "Title";
    public string resultStartBGMName;
    public string resultMainBGMName;
    public string toTitleSeName;

    // Use this for initialization
    void Start () {
        SoundManager.StopBGM();
        //bgmだが、ループはさせない
        SoundManager.PlayBGM(resultStartBGMName,false);
	}
	
	// Update is called once per frame
	void Update () {
        if(SoundManager.GetBGMIsStop())
        {
            SoundManager.PlayBGM(resultMainBGMName);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResultWork.Init();
            SoundManager.PlaySE(toTitleSeName);
            MultiFadeManager.SetNextFade(nextScene);
        }
    }
}
