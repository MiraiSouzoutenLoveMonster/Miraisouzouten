using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveController : MonoBehaviour {

    public GameObject target;
    public float curveSpeed = 1;

    GameObject[] curveObjects;
    float[] curveCount;

    float angle;

    Quaternion[] curveObjectQua;

    int usePlayer = 2;

	// Use this for initialization
	void Start () {
        curveObjects = new GameObject[usePlayer];
        curveCount = new float[usePlayer];
        curveObjectQua = new Quaternion[usePlayer];
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		for(int i = 0; i < curveObjects.Length; i++)
        {
            //オブジェクトが登録されている場合はカーブ処理を行う
            if(curveObjects[i] != null)
            {
                curveCount[i] += Time.deltaTime * curveSpeed;

                curveObjects[i].transform.rotation = Quaternion.Slerp(curveObjectQua[i],target.transform.rotation,curveCount[i]);

                //Debug.Log(curveObjectQua[i]);

                if(curveCount[i] >= 1.0f)
                {
                    curveObjects[i] = null;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーが触れたらカーブさせる
        if (other.transform.tag == "Player")
        {
            for (int i = 0; i < curveObjects.Length; i++)
            {
                //すでに当たっている場合は処理をしない
                if (curveObjects[i] == null && Array.IndexOf(curveObjects, other.gameObject) <= -1)
                {
                    curveObjects[i] = other.gameObject;
                    curveCount[i] = 0;
                    curveObjectQua[i] = other.transform.rotation;

                    Vector3 dir = target.transform.position - curveObjects[i].transform.position;

                    angle = Vector3.Angle(other.transform.forward,dir);
                    break;
                }
            }
        }
    }

}
