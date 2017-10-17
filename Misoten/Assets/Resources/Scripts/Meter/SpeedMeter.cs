using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする

public class SpeedMeter : MonoBehaviour {
    public Image speedMeter;        // 速度メータ
    public Text speedText;          // 速度テキスト
    public float maxSpeed;          // 最大速度

    static float playerMaxSpeed;//プレイヤーの最大スピードを受け取る変数

    float meterAmountSplit;         // メータ表示の分割数
    float meterAmount;              // メータの表示量
    float getSpeed;                 // 速度受け取るよ

    // メータ表示量のセット
    public void SetSpeedMeter(float speed)
    {
        meterAmount = speed * meterAmountSplit + 0.065f;
        speedMeter.fillAmount = meterAmount;
    }
    // テキストの数値のセット
    public void SetSpeedText(float speed)
    {
        int convert = (int)speed;
        speedText.text = (convert).ToString();
        SetSpeedMeter(convert);
    }
    // 速度セットするよ
    public void SetSpeed(float speed)
    {
        if (maxSpeed > speed)
        {
            getSpeed = speed;
        }
    }


    // Use this for initialization
    void Start () {
        playerMaxSpeed = 0;
        meterAmountSplit = 1.0f / maxSpeed;
        getSpeed = 0;
        SetSpeedText(getSpeed);
    }

    // Update is called once per frame
    void Update() {
        SetSpeedText(getSpeed);
        if (Input.GetKey(KeyCode.Space))
        {
            getSpeed += 0.4f;
        }
        else
        {
            getSpeed -= 0.4f;
            if (getSpeed < 0)
            {
                getSpeed = 0;
            }
        }
    }
}
