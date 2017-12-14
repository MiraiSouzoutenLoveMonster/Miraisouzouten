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
    Quaternion rotation;    // アンドロイドの回転

    // キー操作
    bool down;      // 押された
    bool repeat;    // リピート

    // Startの前に行われる処理
    private void Awake()
    {
        // 破棄を無効化
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    public void Init(xPadID id)
    {
        controller = GameObject.Find("OSCHostController").GetComponent<OSCHostConroller>();
        padid = id;
        this.tag = "AndroidInput";
        AndroidInputManager.SetAndroidInput(this);
    }
	
	// Update is called once per frame
	void Update () {
        Input = controller.xPadChannels[padid.ToString()]._input;   // なんか更新
        sensorType = Input.sensorType;                              // 同じくなんか更新

        // アンドロイドの回転取得
        SetRotation();

        // 押された取得
        SetDown();

        // リピート取得
        SetRepeat();
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
    public void SetDown()
    {
        down = Input.GetKeyDown(KeyCode.Z);
    }
    // リピートされてるよ
    public void SetRepeat()
    {
        repeat = Input.GetKey(KeyCode.Z);
    }


    // 回転取得
    public Quaternion GetRotation()
    {
        return rotation;
    }

    // トリガー判定の取得
    public bool GetDown()
    {
        return down;
    }

    // リピート状態取得
    public bool GetRepeat()
    {
        return repeat;
    }
}
