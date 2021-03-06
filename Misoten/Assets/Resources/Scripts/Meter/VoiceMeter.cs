﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする

public class VoiceMeter : MonoBehaviour {
    public MicInput micInput;   // マイクインプット
    public int targetPlayerNumber;         // ディスプレイ番号
    public Image meter;         // メータ

    float meterAmountSplit;     // メータ表示の分割数
    float meterAmount;          // メータの表示量
    float vol;                  // ボリューム

    // メータ表示量のセット
    public void SetVoiceMeter(float volume)
    {
        meterAmount = volume * meterAmountSplit;
        meter.fillAmount = meterAmount;
    }

    // Use this for initialization
    void Start () {
        meterAmountSplit = 1.0f / micInput.GetSensitivity();
    }
	
	// Update is called once per frame
	void Update () {
        vol = micInput.GetLoudness(targetPlayerNumber);
        SetVoiceMeter(vol);
    }
}
