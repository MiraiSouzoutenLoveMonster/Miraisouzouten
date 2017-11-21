using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutIn : MonoBehaviour {

    public float displayTime;   //表示する時間

    protected float countDisplayTime;   //表示時間のカウンタ

	// Use this for initialization
	void Start () {
        countDisplayTime = 0;
    }
	
	// Update is called once per frame
	void Update () {

	}

    protected void CountTime()
    {
        countDisplayTime += Time.deltaTime;

        if (countDisplayTime >= displayTime)
        {
            Destroy(gameObject);
            return;
        }
    }
}
