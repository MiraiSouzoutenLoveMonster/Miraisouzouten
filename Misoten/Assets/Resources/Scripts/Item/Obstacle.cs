using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Item {
    public float downSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public float GetObstacleDownSpeed()
    {
        return downSpeed;
    }

    public override void Effect()
    {

    }

    public override void Effect(PlayerController targetPlayer)
    {
        float speed = targetPlayer.GetPlayerBaseSpeed();

        speed -= downSpeed;

        targetPlayer.SetPlayerBaseSpeed(speed);

        Destroy(gameObject);
    }
}
