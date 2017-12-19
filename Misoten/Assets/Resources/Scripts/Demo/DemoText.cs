using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoText : MonoBehaviour {

    public Text demoTxt;
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float s = speed * Time.deltaTime;
        float alpha = demoTxt.color.a - s;
        if(alpha < 0.0f)
        {
            alpha = 0.0f;
        }
        else if(alpha > 1.0f)
        {
            alpha = 1.0f;
        }
        demoTxt.color = new Color(demoTxt.color.r, demoTxt.color.g, demoTxt.color.b,alpha);

        if(alpha >= 1.0f || alpha <= 0.0f)
        {
            speed *= -1.0f;
        }
	}
}
