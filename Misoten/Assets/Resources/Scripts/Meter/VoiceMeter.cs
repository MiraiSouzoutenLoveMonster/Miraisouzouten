using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする

public class VoiceMeter : MonoBehaviour {
    public MicInput micInput;   // マイクインプット
    public int display;         // ディスプレイ番号
    public Image back;          // 背景
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
        display = display - 1;
        meterAmountSplit = 1.0f / micInput.GetSensitivity();
    }
	
	// Update is called once per frame
	void Update () {
        vol = micInput.GetLoudness(display);
        SetVoiceMeter(vol);
    }
}
