using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    NORMAL = 0,
    SLIP,
    COLLISION,
    MAX
}

public class PlayerController : MonoBehaviour {

    public Rigidbody rigid;
    public float movePower;

    public float collisionTime;//プレイヤーが壁とぶつかった後操作不能になる時間

    static public PlayerState playerState;

    float countCollisionTime;

    // Use this for initialization
    void Start () {
        playerState = PlayerState.NORMAL;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float rotY = Input.GetAxis("Horizontal");

        transform.Rotate(0, rotY, 0);

        if(Input.GetKey(KeyCode.W) && playerState == PlayerState.NORMAL)
        {
            rigid.AddForce(transform.forward * movePower);
        }

        if(playerState == PlayerState.COLLISION)
        {

        }
    }

    public static PlayerState GetPlayerState()
    {
        return playerState;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
