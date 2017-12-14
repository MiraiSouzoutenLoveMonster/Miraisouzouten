using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームフェーズ
public enum GamePhase
{
    PHASE_CAMERAPERFORMANCE = 0,
    PHASE_READY,
    PHASE_GAME,
    PHASE_FINISH
}

public class GameSceneManager : MonoBehaviour {
    public string nextScene = "Result";
    public StartManager startManager;

    public GamePhase startPhase = GamePhase.PHASE_CAMERAPERFORMANCE;
    static GamePhase phase = GamePhase.PHASE_CAMERAPERFORMANCE;//ゲームのフェーズ

    public string gameStartBgmName;
    public string gameMainBGM;

    // Use this for initialization
    void Start () {
        phase = startPhase;
        startManager.SetStartActive(false);
        SoundManager.PlayBGM(gameStartBgmName);
        //startManager.SetStartActive(true);
        //KeijibanClient.SendData("金賞の風格OGSWRBB.png");
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    //MultiFadeManager.SetNextFade(nextScene,0);

        //    KeijibanClient.SendData("2");
        //}

        if(phase == GamePhase.PHASE_READY)
        {
            startManager.SetStartActive(true);
        }

        if(phase == GamePhase.PHASE_GAME)
        {
            SoundManager.PlayBGM(gameMainBGM);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            MultiFadeManager.SetNextFade("Result");
        }
	}

    public static void SetGamePhase(GamePhase nextPhase)
    {
        phase = nextPhase;
    }

    public static GamePhase GetGamePhase()
    {
        return phase;
    }
}
