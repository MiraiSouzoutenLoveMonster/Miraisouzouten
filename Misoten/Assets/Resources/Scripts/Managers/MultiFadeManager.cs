using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // シーン移るのにいる

public class MultiFadeManager : MonoBehaviour {
    // 注意-----------------------------
    // ビルドしてシーンの登録しといてね
    // ---------------------------------
    public enum FADE_MODE           // フェードの状態
    {
        FADE_NONE = 0,
        FADE_IN,
        FADE_OUT,
    }
    [System.Serializable]
    public class FADE_TIME
    {
        [Range(0.1f, 5.0f)]
        public float outTime = 0.1f;    // 暗くなるよ
        [Range(0.1f, 5.0f)]
        public float inTime = 0.1f;     // 見えてくるよ
    }

    public FADE_TIME[] inputFadeType;//入力用のフェード時間

    static public FADE_TIME[] fadeType;    // ここで時間別のフェードを入れておいてね
    public int playerMax;           // プレイヤーの人数だよ
    public GameObject fadeCanvas;   // キャンバスのプレファイブだよ
    public Sprite texture;          // テクスチャ こっちに張り付けてね


    static FADE_MODE mode;                 // モードだよ
    GameObject[] canvas;            // これ弄ってるよ
    Image[] child;                  // 子供だよ
    static int nowType;                    // 現在のタイプだよ
    static Color color;                    // 色だよ
   static string nextScene;               // 次のシーンだよ 名前で指定だよ
    static float fps = 1.0f / 60.0f;       // α値の最大値 1.0f を fps(60)で割ったよ
    static float speed;                    // 加算される値だよ

    // Startの前に行われる処理
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);         // 消えなくなるよ

        fadeType = new FADE_TIME[inputFadeType.Length];
        Array.Copy(inputFadeType,fadeType,fadeType.Length);
    }
    // Use this for initialization
    void Start () {
        canvas = new GameObject[playerMax];     // キャンバス作るよ
        child = new Image[playerMax];           // 画像覚えるよ
        nowType = 0;                               // タイプっぽいよ

        // 作るよ
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i] = Instantiate(fadeCanvas);                // キャンバス作ったよ
            canvas[i].transform.parent = transform;             // マネージャーの子供にしたよ
            canvas[i].GetComponent<Canvas>().targetDisplay = i+1; // キャンバスの表示対象決めたよ
            child[i] = canvas[i].gameObject.GetComponentInChildren<Image>();    // イメージ覚えておくよ
            color = child[i].color;                                             // イメージの色覚えておくよ
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        // なんもないなら処理しないよ
        if (mode != FADE_MODE.FADE_NONE)
        {
            // 見えなくなってくるよ
            if (mode == FADE_MODE.FADE_OUT || mode == FADE_MODE.FADE_IN)
            {
                color.a += speed;
                // ここで全ての画像の色更新
                for (int i = 0; i < canvas.Length; i++)
                {
                    child[i].color = color;
                }

                // 1超えたら真っ暗だからシーン移動するよ
                if (color.a > 1.0f)
                {
                    speed = -(fps / fadeType[nowType].inTime); // 時間変えるよ
                    mode = FADE_MODE.FADE_IN;               // 見えてくるようにするよ
                    // シーン移動するよ
                    if (nextScene != null)
                    {
                        SceneManager.LoadScene(nextScene);
                        nextScene = null;
                    }
                }
                // 0以下なったら待機状態なるよ
                else if (color.a < 0)
                {
                    color.a = 0;
                    mode = FADE_MODE.FADE_NONE;
                }
            }
        }
    }

    // 自分を渡すよ
    public MultiFadeManager GetObject()
    {
        return this;
    }

    // モード渡すよ
    public FADE_MODE GetMode()
    {
        return mode;
    }

    // 次のシーンへ行くフェード
    static public bool SetNextFade(string next, int type = 0)
    {
        if (mode == FADE_MODE.FADE_NONE && type < fadeType.Length)
        {
            nowType = type;
            speed = fps / fadeType[nowType].outTime;
            color.a = 0;                // アルファ値初期化
            nextScene = next;           // 次のシーン
            mode = FADE_MODE.FADE_OUT;  // フェードOUTへ
            return true;
        }
        return false;
    }

    // 暗転だけのフェード
    static public bool SetFade(int type)
    {
        if (mode == FADE_MODE.FADE_NONE && type < fadeType.Length)
        {
            nowType = type;
            speed = fps / fadeType[type].outTime;
            color.a = 0;                // アルファ値初期化
            mode = FADE_MODE.FADE_OUT;  // フェードOUTへ
            return true;
        }
        return false;
    }


}
