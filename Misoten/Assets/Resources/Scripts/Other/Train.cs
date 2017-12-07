using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public GameObject effect;
    public float effectPower;

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
            PlayerController p = other.gameObject.GetComponent<PlayerController>();
            p.SetPlayerEffectiveSpeed(effectPower);
            GameObject obj = Instantiate(effect,other.gameObject.transform);
            //obj.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
