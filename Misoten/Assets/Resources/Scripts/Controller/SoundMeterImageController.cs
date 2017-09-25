using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeterImageController : MonoBehaviour {

    public SoundMeter[] meter;

    public float vol;//基準となるボリューム

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool SetIsDraw(float volume)
    {
        if (vol <= volume)
        {
            for (int i = 0; i < meter.Length; i++)
            {
                meter[i].SetColor(new Vector3(1,1,1));
                meter[i].SetAlpha(1);
            }
            return true;
        }

        else
        {
            for (int i = 0; i < meter.Length; i++)
            {
                meter[i].SetColor(new Vector3(0,0,0));
                meter[i].SetAlpha(0.25f);
            }
            return false;
        }
    }

    public void SetColor(Vector3 col)
    {
        for(int i = 0; i < meter.Length; i++)
        {
            meter[i].SetColor(col);
        }
    }
}
