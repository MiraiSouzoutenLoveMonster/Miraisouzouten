using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpeed : MonoBehaviour {

    public ParticleSystem particle;     //パーティクル本体
	// Use this for initialization
	void Start () {
        particle = GetComponent<ParticleSystem>();
        particle.playbackSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
