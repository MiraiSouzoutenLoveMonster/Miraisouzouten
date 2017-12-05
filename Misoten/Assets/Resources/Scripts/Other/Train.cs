using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public GameObject effect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触したらエフェクトを発生させてオブジェクトを削除
        if(other.tag == "Player")
        {
            GameObject obj = Instantiate(effect,other.gameObject.transform);
            //obj.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
