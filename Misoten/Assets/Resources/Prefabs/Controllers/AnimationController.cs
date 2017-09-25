using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator animator;               //自身のアニメーターを設定
    public float speed;
    public Rigidbody rigid;
    public float movePower;

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

        transform.Rotate(0,Input.GetAxis("Horizontal"),0);

		if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
            rigid.AddForce(transform.forward * movePower);
        }

        else
        {
            animator.SetBool("Walk", false);
        }     
    }
}
