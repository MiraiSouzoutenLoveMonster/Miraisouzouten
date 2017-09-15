using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    NORMAL = 0,
    SLIP,
    MAX
}

public class PlayerController : MonoBehaviour {

    public Rigidbody rigid;
    public float moveSpeed;

    static public PlayerState playerState;

    // Use this for initialization
    void Start () {
        playerState = PlayerState.NORMAL;
	}
	
	// Update is called once per frame
	void Update () {
       //transform.Rotate(0,45*Time.deltaTime,0);

        float x, z;
        x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 dir = new Vector3(x,0,z);

        if(dir.magnitude > 0.01f)
        {
            float step = 2.0f * Time.deltaTime;
            Quaternion qua = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation,qua,step);
        }

        rigid.velocity = new Vector3(x,0,z);
    }

    public static PlayerState GetPlayerState()
    {
        return playerState;
    }
}
