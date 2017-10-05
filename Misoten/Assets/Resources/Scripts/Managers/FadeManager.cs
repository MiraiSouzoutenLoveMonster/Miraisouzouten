using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UIを使用可能にする
using UnityEngine.SceneManagement;  // シーン遷移の関数を呼び出すために必要

public class FadeManager : MonoBehaviour {
    // 注意-----------------------------
    // ビルドしてシーンの登録しといてね
    // ---------------------------------
    public enum FADE_MODE           // フェードの状態
    {
        FADE_NONE = 0,
        FADE_IN,
        FADE_OUT,
    }
    public Sprite texture;          // テクスチャ こっちに張り付けてね
    [Range(0, 1.0f)]
    public float speed = 1.0f;     // 透明化の速さ

    public GameObject _child;   // パネルに使われるオブジェクト
    public Image childColor;           //子オブジェクトのRGBA値
    static FADE_MODE mode;             // フェードの状態
    static Color color;                // 色の値
    static string nextScene;           // 次のシーン

    // Startの前に行われる処理
    private void Awake()
    {
        // 破棄を無効化
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        nextScene = null;           // 次のシーン初期化
        mode = FADE_MODE.FADE_NONE;

        // 色の初期化
        color.r = childColor.color.r;
        color.g = childColor.color.g;
        color.b = childColor.color.b;
        color.a = 0;

        SetTexture(texture);
    }

    // Update is called once per frame
    void Update () {
        if (mode != FADE_MODE.FADE_NONE)
        {
            // 画面を暗転化する
            if (mode == FADE_MODE.FADE_OUT)
            {
                childColor.color = new Color(color.r, color.g, color.b, color.a);
                color.a += speed / 100;
            }
            // 画面を見えるように戻す
            else if (mode == FADE_MODE.FADE_IN)
            {
                childColor.color = new Color(color.r, color.g, color.b, color.a);
                color.a -= speed / 100;
            }

            // 制御
            if (color.a > 1.0f)
            {
                Debug.Log("画面暗転終了");
                // フェードINへ移行
                mode = FADE_MODE.FADE_IN;
                if( nextScene != null )
                {
                    // シーン移行
                    SceneManager.LoadScene(nextScene);
                    nextScene = null;
                }
            }
            else if (color.a < 0)
            {
                Debug.Log("フェード終了");
                // フェード終了
                color.a = 0;
                mode = FADE_MODE.FADE_NONE;
            }
        }

    }

    // テクスチャの貼り付け
    void SetTexture(Sprite tex)
    {
        childColor.sprite = tex;
    }

    // フェード状態取得
    public FADE_MODE GetFadeMode()
    {
        return mode;
    }

    // 次のシーンへ行くフェード
    static public bool SetNextFade(string next)
    {
        if (mode == FADE_MODE.FADE_NONE)
        {
            Debug.Log("フェード呼び出し : " + next);

            color.a = 0;                // アルファ値初期化
            nextScene = next;           // 次のシーン
            mode = FADE_MODE.FADE_OUT;  // フェードOUTへ
            return true;
        }
        return false;
    }

    // 暗転だけのフェード
    static public bool SetFade()
    {
        if (mode == FADE_MODE.FADE_NONE)
        {
            Debug.Log("暗転フェード呼び出し" );
            color.a = 0;                // アルファ値初期化
            mode = FADE_MODE.FADE_OUT;  // フェードOUTへ
            return true;
        }
        return false;
    }
}
