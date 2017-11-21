using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherEffect : Effect {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (particle.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
