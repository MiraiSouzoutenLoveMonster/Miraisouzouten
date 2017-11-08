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
    public float horizontalMovePower;
    public float rotXPower;

    public float collisionTime;//プレイヤーが壁とぶつかった後操作不能になる時間

    public LayerMask targetLayer;

    public PlayerState playerState;

    float playerSpeed;

    public Camera playerCamera;

    public int playerNumber;

    Quaternion androidQuaternion;

    Quaternion defaultQuaternion;

    public MicInput mic;

    public float voicePower;

    public float maxSpeed;
    public float maxBaseSpeed;       //声量が0のときの最大速度
    float baseSpeed;                    //プレイヤーの基礎速度

    public bool isDebug;

    // Use this for initialization
    void Start () {
        playerState = PlayerState.NORMAL;
        playerSpeed = 0;

        Physics.gravity = new Vector3(0,-9.81f * 200, 0);

        defaultQuaternion = transform.rotation;

        baseSpeed = 50;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(GameSceneManager.GetGamePhase() == GamePhase.PHASE_READY)
        {
            return;
        }

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

        //float rotX = Input.GetAxis("Horizontal");

        //基礎速度が最大値に満たない場合は基礎速度を上げていく
        if(baseSpeed <= maxBaseSpeed)
        {
            baseSpeed += Time.deltaTime * 3;
        }

        Debug.Log(baseSpeed);

        float rotX;
        AndroidInput input;
        //エディタだったらデバッグ判定をとって操作系を判定
        //実機だったらAndroidInput固定
        if (Application.isEditor)
        {
            if(isDebug)
            {
                if(playerNumber == 0)
                {
                    rotX = -Input.GetAxis("Horizontal");
                }
                else
                {
                    rotX = -Input.GetAxis("Horizontal2P");
                }

                androidQuaternion = new Quaternion(0, rotX*0.15f, 0, 1);
            }
            else
            {
                input = AndroidInputManager.GetAndroidInput(playerNumber);
                androidQuaternion = input.GetRotation();

                if (androidQuaternion.y >= -0.15f && androidQuaternion.y <= 0.15f)
                {
                    androidQuaternion = new Quaternion(androidQuaternion.x, androidQuaternion.y * 1, androidQuaternion.z, androidQuaternion.w);
                }
            }
        }

        else
        {
            input = AndroidInputManager.GetAndroidInput(playerNumber);
            androidQuaternion = input.GetRotation();

            if (androidQuaternion.y >= -0.15f && androidQuaternion.y <= 0.15f)
            {
                androidQuaternion = new Quaternion(androidQuaternion.x, androidQuaternion.y * 1, androidQuaternion.z, androidQuaternion.w);
            }
        }

        switch (playerState)
        {
            case PlayerState.NORMAL:
                float loudness = mic.GetLoudness(playerNumber);
                //float loudness = 10.0f;
                Vector3 velocity = transform.forward * (baseSpeed + (maxSpeed - maxBaseSpeed) * (loudness / voicePower));
                //Vector3 velocity = transform.forward * baseSpeed * movePower;
                rigid.velocity = velocity;
                playerSpeed = rigid.velocity.magnitude;
                rigid.velocity += transform.right * -androidQuaternion.y * horizontalMovePower;
                rigid.AddForce(rigid.velocity, ForceMode.Acceleration);

                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,defaultQuaternion.eulerAngles.z + rotXPower * androidQuaternion.y);
                break;

            case PlayerState.CURVE:
                
                break;
        }

        if (playerState == PlayerState.CURVE)
        {
            playerSpeed = 45.0f;
        }

        ResultWork.SetMaxSpeed(playerNumber,playerSpeed);
    }

    private void LateUpdate()
    {
        //RaycastHit hitInfo;
        //if (Physics.Raycast(transform.position, Vector3.down,
        //    out hitInfo, Mathf.Infinity, targetLayer))
        //{
        //    Vector3 newPos = transform.position;
        //    newPos.y = hitInfo.point.y+1;
        //    transform.position = newPos;
        //}
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public void SetPlayerStatus(PlayerState state)
    {
        playerState = state;
        defaultQuaternion = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Obstacle obs = other.gameObject.GetComponent<Obstacle>();

            float effect = obs.GetObstacleDownSpeed();

            baseSpeed -= effect;
        }
    }

    public Rigidbody GetRigidBody()
    {
        return rigid;
    }

    public void CameraActivate(bool active)
    {
        playerCamera.gameObject.SetActive(active);
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

    public float GetPlayerSpeed()
    {
        if (playerSpeed >= 399.0f)
        {
            playerSpeed = 399.0f;
        }
        return playerSpeed;
    }
}
