using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour {
    // プレイヤーの左右移動のデータクラス
    [System.Serializable]
    public class InitData
    {
        public GameObject playerObj;    // プレイヤー
        public Vector3 position;        // 位置
        public Vector3 rotation;        // 回転
    }
    public InitData[] initData;         // 初期データ
    GameObject[] player;                // プレイヤークラスに変えてどうぞ

    // プレイヤー取得
    public GameObject GetPlayer(int i)
    {
        if ( i < player.Length && player[i] != null)
        {
            return player[i];
        }
        return null;
    }

    // Use this for initialization
    void Awake () {
        player = new GameObject[initData.Length];
        PlayerController obj = GetComponent<PlayerController>();

        for (int i = 0; i < player.Length; i ++)
        {
            player[i] = Instantiate(initData[i].playerObj);
            player[i].transform.position = initData[i].position;
            player[i].transform.rotation = new Quaternion( initData[i].rotation.x, initData[i].rotation.y, initData[i].rotation.z, 0);
            //obj.SetPlayer(player[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
