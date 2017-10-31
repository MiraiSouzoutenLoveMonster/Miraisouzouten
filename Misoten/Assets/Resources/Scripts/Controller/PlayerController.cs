using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    NORMAL = 0,
    SLIP,
    COLLISION,
    CURVE,
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

    public Camera playerCamera;

    public int playerNumber;

    // Use this for initialization
    void Start () {
        playerState = PlayerState.NORMAL;
        playerSpeed = 0;

        Physics.gravity = new Vector3(0,-9.81f * 200, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

       // movePower++;

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

        switch (playerState)
        {
            case PlayerState.NORMAL:
                rigid.velocity = transform.forward * movePower;
                rigid.AddForce(transform.forward * movePower, ForceMode.Acceleration);
                break;

            case PlayerState.CURVE:

                break;
        }

        if (playerState == PlayerState.CURVE)
        {

        }

        playerSpeed = rigid.velocity.magnitude;

        ResultWork.SetMaxSpeed(playerNumber,playerSpeed);

        //RaycastHit hitInfo;
        //if(Physics.Raycast(transform.position,Vector3.down,
        //    out hitInfo,Mathf.Infinity,targetLayer))
        //{
        //    Vector3 newPos = transform.position;
        //    newPos.y = hitInfo.point.y;
        //    transform.position = newPos;
        //}
    }

    public static PlayerState GetPlayerState()
    {
        return playerState;
    }

    public void SetPlayerStatus(PlayerState state)
    {
        playerState = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Curve")
        {
            //playerState = PlayerState.CURVE;
        }
    }

    public void ChangeDefaultCameraActive()
    {
        playerCamera.gameObject.SetActive(!playerCamera.gameObject.active);
    }

    public Rigidbody GetRigidBody()
    {
        return rigid;
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
}
