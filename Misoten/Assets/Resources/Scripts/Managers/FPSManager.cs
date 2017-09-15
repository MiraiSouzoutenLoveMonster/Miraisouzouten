using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSManager : MonoBehaviour {

    private static FPSManager instance;

    public bool idDebug;

    private int countFPS;//fpsのカウンタ
    private float countRunTime;//ゲームの実行時間のカウンタ

    public Text textObject;//FPS表示用オブジェクト

    // Use this for initialization
    void Start () {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        countFPS = 0;
        countRunTime = 0.0f;

        //QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        DontDestroyOnLoad(gameObject);

        gameObject.SetActive(idDebug);

        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        countFPS++;
        float time = Time.realtimeSinceStartup - countRunTime;

        if(time >= 0.5f)
        {
            textObject.text = "FPS："+(countFPS/time).ToString("f2");

            countFPS = 0;
            countRunTime = Time.realtimeSinceStartup;
        }
    }
}
