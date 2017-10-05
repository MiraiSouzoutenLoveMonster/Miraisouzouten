using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInput : MonoBehaviour {
    //for Unipad Controlls.
    private xInputType sensorType = xInputType.GYROATTITUDE;
    public xPadID padid;
    public OSCHostConroller controller;
    public xMultiInputs Input;
    // ↑アンドロイドとの通信のため上4つは必須
    public bool showGUI;    // GUI表示フラグ
    Quaternion rotation;    // アンドロイドの回転

    // Use this for initialization
    public void Init(xPadID id)
    {
        controller = GameObject.Find("OSCHostController").GetComponent<OSCHostConroller>();
        padid = id;
        this.tag = "AndroidInput";
        //GameObject.Find("PlayerManager").GetComponent<PlayerController>().SetAndroidInput(this);
    }
	
	// Update is called once per frame
	void Update () {
        Input = controller.xPadChannels[padid.ToString()]._input;   // なんか更新
        sensorType = Input.sensorType;                              // 同じくなんか更新

        Debug.Log(GetPush());

        // アンドロイドの回転取得
        SetRotation();
    }

    // アンドロイドの回転セット
    void SetRotation()
    {
        Quaternion getRot = Input.gyro.attitude;
        if (getRot.x != 0 && getRot.y != 0 && getRot.z != 0)
        {
            rotation = getRot;
        }
    }

    // ボタン押すよ
    public bool GetPush()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }

    // 回転取得
    public Quaternion GetRotation()
    {
        return rotation;
    }

    void OnGUI()
    {
        if (showGUI == true)
        {
            string text = (rotation).ToString();
            // テキストフィールドを表示する
            GUI.TextField(new Rect(150, 10 + 25 * (int)padid, 150, 25), text);
        }
    }
}
