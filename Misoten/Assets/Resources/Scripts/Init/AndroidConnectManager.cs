using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidConnectManager : MonoBehaviour {

    public Text[] port;
    public Text[] ip;
    public Text[] connectedText;

    OSCHostConroller osController;
    Dictionary<string, xPadChannel> xPadChannels;

	// Use this for initialization
	void Start () {
        osController = GameObject.Find("OSCHostController").GetComponent<OSCHostConroller>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //入力データの取得ができていないなら取得を試みる
        if(osController == null)
        {
            osController = GameObject.Find("OSCHostController").GetComponent<OSCHostConroller>();
        }
        else if(xPadChannels == null)
        {
            xPadChannels = osController.GetxPadChannels();
        }
        else
        {
            int countPad = 0;
            foreach(KeyValuePair<string, xPadChannel> kvp in xPadChannels)
            {
                port[countPad].text = "PORT："+ kvp.Value.outGoingPort.ToString();
                ip[countPad].text = "IP：" + Network.player.ipAddress;
                if(kvp.Value._input.enable)
                {
                    connectedText[countPad].text = "Connected.";
                }
                else
                {
                    connectedText[countPad].text = "Not Connected.";
                }
                countPad++;
            }
        }
	}
}
