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

    public LayerMask targetLayer;

    static public PlayerState playerState;

    float countCollisionTime;

    float playerSpeed;

    // Use this for initialization
    void Start () {
        playerState = PlayerState.NORMAL;
        playerSpeed = 0;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //float rotY = Input.GetAxis("Horizontal");

        //transform.Rotate(0, rotY*3, 0);

        //if(Input.GetKey(KeyCode.W) && playerState == PlayerState.NORMAL)
        //{
        //    //rigid.AddForce(transform.forward * movePower);
        //    rigid.velocity = transform.forward * movePower;
        //}
        //else
        //{
        //    rigid.velocity = Vector3.zero;
        //}

        Debug.Log(transform.forward);

        rigid.velocity = transform.forward * movePower;

        if (playerState == PlayerState.COLLISION)
        {

        }

        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position,Vector3.down,
            out hitInfo,Mathf.Infinity,targetLayer))
        {
            Vector3 newPos = transform.position;
            newPos.y = hitInfo.point.y;
            transform.position = newPos;
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
