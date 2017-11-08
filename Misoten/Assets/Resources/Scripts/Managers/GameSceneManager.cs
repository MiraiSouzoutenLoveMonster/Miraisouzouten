using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームフェーズ
public enum GamePhase
{
    PHASE_READY = 0,
    PHASE_GAME,
    PHASE_FINISH
}

public class GameSceneManager : MonoBehaviour {
    public string nextScene = "Result";
    public StartManager startManager;

    static GamePhase phase = GamePhase.PHASE_READY;//ゲームのフェーズ

    // Use this for initialization
    void Start () {
        phase = GamePhase.PHASE_READY;
        //startManager.SetStartActive(false);
        startManager.SetStartActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            startManager.SetStartActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            MultiFadeManager.SetNextFade(nextScene,0);
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
