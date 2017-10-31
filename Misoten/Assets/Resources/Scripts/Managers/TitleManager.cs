using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TitleManager : MonoBehaviour {

    public string nextScene = "Game";

    // Use this for initialization
    void Start () {
        SoundManager.StopBGM();
        SoundManager.PlayBGM("gameBGM_totyu");
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.PlaySE("goto_game_kansei_aud");
            MultiFadeManager.SetNextFade(nextScene,0);
        }
	}
}
