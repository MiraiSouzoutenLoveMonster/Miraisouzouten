using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Target;

    Vector3 start;
    Vector3 startRot;
    float time;

	// Use this for initialization
	void Start () {
        start = transform.position;
        time = 0.0f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(time <= 1.0f)
        {
            time += Time.deltaTime;

            transform.position = Vector3.Slerp(start, Target.transform.position, time);

            
        }
    }
}
