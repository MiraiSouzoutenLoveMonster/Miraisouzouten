using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour {
    public string nextScene = "Result";
    public StartManager startManager;

    // Use this for initialization
    void Start () {
        startManager.SetStartActive(false);
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
}
