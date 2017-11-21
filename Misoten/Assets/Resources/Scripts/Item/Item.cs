using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //アイテムの効果
    public virtual void Effect()
    {

    }

    public virtual void Effect(PlayerController targetPlayer)
    {

    }
}
