﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator animator;               //自身のアニメーターを設定

    Vector3 oldRot;
	// Use this for initialization
	void Start () {
        oldRot = Vector3.zero;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(animator == null)
        {
            return;
        }

		if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }

        else
        {
            animator.SetBool("Walk", false);
        }     
    }
}
