using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveCamera : MonoBehaviour {

    GameObject targetPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPlayer != null)
        {
            Vector3 vec = targetPlayer.transform.position - transform.position;

            Quaternion qua = Quaternion.LookRotation(vec);

            transform.localRotation = qua;
        }
	}

    public void SetTargetPlayer(GameObject target)
    {
        targetPlayer = target;
    }
}
