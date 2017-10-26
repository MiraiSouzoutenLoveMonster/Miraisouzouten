using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする

public class ResultManager : MonoBehaviour {
    public string nextScene = "Title";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResultWork.Init();
            MultiFadeManager.SetNextFade(nextScene);
        }
    }
}
