using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour {
    /// <summary>
    /// 構造体
    /// </summary>
    // アイテムタイプ
    public enum ITEM_TYPE
    {
        TYPE_KIBAKO = 0,    // 木箱
        TYPE_TARU,          // た～るっ
    }

    /// <summary>
    /// クラス
    /// </summary>
    // 設置場所
    [System.Serializable]
    public class Installation
    {
        public Vector3 position;
        public ITEM_TYPE type;
    }
    // Inspe
    public GameObject[] itemPrefab;                     // Prefab入れるよ
    static public GameObject[] ItemObject;              // アイテムオブジェだよ
    public Installation[] installation;                 // 設置場所とタイプだよ


    // Use this for initialization
    void Start () {
        // コピるよ
        ItemObject = itemPrefab;

        // 初期設置アイテムを作るよ
        for ( int i = 0; i < installation.Length; i ++ )
        {
            SetItem(installation[i].type, installation[i].position );
        }
	}

    // Update is called once per frame
    void Update()
    {
    }

    // アイテムをセットするよ
    static public void SetItem( ITEM_TYPE type, Vector3 pos)
    {
        GameObject item;                                // アイテムのクラスだよ
        item = Instantiate(ItemObject[(int)type],       // Prefabから呼ぶよ
                            pos,                    // 位置だよ
                            Quaternion.identity);   // 回転だよ
    }
}
