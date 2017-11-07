using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;      //!< デプロイ時にEditorスクリプトが入るとエラーになるので UNITY_EDITOR で括ってね！
#endif

public class test : MonoBehaviour
{
    public List<GameObject> wayPoint = new List<GameObject>();  // わかるだろ？
    
    // wayPointのListを取得
    public List<GameObject> GetWayPointList()
    {
        return wayPoint;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(test))]               //!< 拡張するときのお決まりとして書いてね
    public class testEditor : Editor           //!< Editorを継承するよ！
    {
        bool folding = false;   //折り畳みのフラグだよ

        // インスペ拡張するよ
        public override void OnInspectorGUI()
        {
            test testo = target as test;                            // メインのインスペ貰うで
            List<GameObject> wayList = testo.GetWayPointList();     // WayPointのリスト貰うで

            // 折りたたみ表示
            if (folding = EditorGUILayout.Foldout(folding, "WayPoint"))
            {
                EditorGUILayout.BeginHorizontal();      // 開始
                GameObject addObj = EditorGUILayout.ObjectField(null, typeof(GameObject), true) as GameObject;
                if (GUILayout.Button("+", GUILayout.Width(50f)))
                {
                }
                if (GUILayout.Button("-", GUILayout.Width(50f)))
                {
                }
                EditorGUILayout.EndHorizontal();        // 終了

                for (int i = 0; i < wayList.Count; i++)
                {
                    wayList[i] = EditorGUILayout.ObjectField(wayList[i], typeof(GameObject), true) as GameObject;
                }


                if (GUILayout.Button("名前ええええ"))
                {
                    // 押下時に実行したい処理
                }
            }

        }
    }
#endif
}