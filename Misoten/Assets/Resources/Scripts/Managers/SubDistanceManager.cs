using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubDistanceManager : MonoBehaviour {

    public Text enemyDistance;//"相手との距離"表示用オブジェクト
    public Text subDistance;//相手との距離の数値表示用オブジェクト

    public GameObject player1;
    public GameObject player2;

    public GameObject goal;

    public float underLine;

	// Use this for initialization
	void Start () {
        enemyDistance.text = "相手との距離";
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float distance = (player1.transform.position - player2.transform.position).sqrMagnitude;

        distance /= 1000.0f;

        if (distance <= underLine)
        {
            distance = 0.0f;
        }

        subDistance.text = ((int)distance).ToString();

    }
}
