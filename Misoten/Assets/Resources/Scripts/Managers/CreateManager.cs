using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public GameObject[] prefab;         // ここに消したくないオブジェ
    GameObject[] obj;                   // こっち弄る

    // 名前指定でオブジェ取得
    GameObject GetObject(string name)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].name == name)
            {
                return obj[i];
            }
        }
        return null;
    }

    // Use this for initialization
    void Awake()
    {
        // オブジェを消えないように作るよ
        obj = new GameObject[prefab.Length];

        // プレイファブ分回すよ
        for (int i = 0; i < prefab.Length; i++)
        {
            // 初期化してfindするよ
            obj[i] = null;
            obj[i] = GameObject.Find(prefab[i].name);

            // find したのにないから作るよ
            if (obj[i] == null)
            {
                obj[i] = Instantiate(prefab[i]) as GameObject;  // 消えないように作るよ
                obj[i].name = prefab[i].name;                   // cloneがついてるから消すよ
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
