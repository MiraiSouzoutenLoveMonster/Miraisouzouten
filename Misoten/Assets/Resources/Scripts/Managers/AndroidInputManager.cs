using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInputManager : MonoBehaviour {
    public bool showGUI = false;
    static List<AndroidInput> input;

    // Startの前に行われる処理
    private void Awake()
    {
        // 破棄を無効化
        DontDestroyOnLoad(this.gameObject);
        input = new List<AndroidInput>();
    }

    // Use this for initialization
    void Start () {
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            showGUI = false;
        }
    }


	// Update is called once per frame
	void Update () {
	}

    // AndroidInputを入れる
    static public int SetAndroidInput(AndroidInput obj)
    {
        if (obj != null)
        {
            input.Add(obj);
        }
        return input.Count;
    }


    // 入力情報を取得 番号で指定
    static public AndroidInput GetAndroidInput(int i)
    {
        return input[i];
    }

    // 入力情報を取得 番号で指定
    static public List<AndroidInput> GetAndroidInputList()
    {
        return input;
    }

    // 接続数を取得
    static public int GetConnectInputCount()
    {
        return input.Count;
    }

    void OnGUI()
    {
        if (showGUI == true)
        {
            string text;
            for (int i = 0; i < input.Count; i ++)
            {
                text = (input[i].GetRotation()).ToString();
                GUI.TextField(new Rect(150, 10 + 25 * i, 150, 25), text);
            }
        }
    }
}
