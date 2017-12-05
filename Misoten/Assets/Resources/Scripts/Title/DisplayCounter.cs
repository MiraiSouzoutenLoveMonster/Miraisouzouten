using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCounter : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        text.text = Display.displays.Length.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
