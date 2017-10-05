using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicInput : MonoBehaviour
{
    [System.Serializable]
    public class MicClass
    {
        public AudioSource audio;       // オーディオだよ マイクに使うよ
        public string deviceName;       // マイクの名前だよ

        // こいつら見えなくするよ
        [System.NonSerialized]
        public float loudness;          //音量.
        [System.NonSerialized]
        public float lastLoudness;      //前フレームの音量.
    }

    public MicClass[] mic;              // マイクだよ
    public float sensitivity = 100;     //感度.音量の最大値.
    [Range(0, 0.95f)]                   //最大1にできてしまうと全く変動しなくなる.
    public float lastLoudnessInfluence; //前フレームの影響度合い. 残響の影響みたいなもん
    public bool showGUI = false;        // GUI

    // 声量を外部へ渡す
    public float GetLoudness(int i)
    {
        return mic[i].loudness;
    }
    // 音量最大値を渡す
    public float GetSensitivity()
    {
        return sensitivity;
    }


    // Use this for initialization
    void Start()
    {
        // マイクの名前の正規変換
        for (int i = 0; i < mic.Length; i++)
        {
            for(int j = 0; j < Microphone.devices.Length; j ++ )
            {
                if (0 <= Microphone.devices[j].IndexOf(mic[i].deviceName))
                {
                    mic[i].deviceName = Microphone.devices[j];
                    Debug.Log("Name: " + mic[i].deviceName);
                }
            }
        }

        // マイク作るよ
        for (int i = 0; i < mic.Length; i++)
        {
            mic[i].audio.clip = Microphone.Start(mic[i].deviceName, true, 999, 44100);   // マイクからのAudio-InをAudioSourceに流す
            mic[i].audio.loop = true;                                                   // ループ再生にしておく
        }

        while (!(Microphone.GetPosition("") > 0)) { }                               // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる

        for (int i = 0; i < mic.Length; i++)
        {
            mic[i].audio.Play();                                                        // 再生する
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mic.Length; i++)
        {
            mic[i].lastLoudness = mic[i].loudness;
            mic[i].loudness = GetAveragedVolume(i) * sensitivity * (1 - lastLoudnessInfluence) + mic[i].lastLoudness * lastLoudnessInfluence;
        }
    }

    //現フレームで再生されている AudioClip から平均的な音量を取得します.
    float GetAveragedVolume(int id )
    {
        float[] data = new float[256];          //AudioClip の情報を格納する配列.
        float vol = 0;                          // 返却用の値
        mic[id].audio.GetOutputData(data, 0);    //AudioClipからデータを抽出します.

        //音データを絶対値に変換します.
        foreach (float i in data)
        {
            vol += Mathf.Abs(i);
        }
        //平均を返します.
        return vol / 256;
    }

    // 声量表示
    void OnGUI()
    {
        if (showGUI == true)
        {        // マイク作るよ
            for (int i = 0; i < mic.Length; i++)
            {
                string text;                            // 表示用のtext
                text = (mic[i].loudness).ToString();    // 声量の数値をstringに変換
                // テキストフィールドを表示する
                GUI.TextField(new Rect(150, 50 + i * 50 , 150, 25), text);
            }
        }

    }
}
