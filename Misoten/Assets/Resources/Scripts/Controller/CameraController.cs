using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;//追従させる対象オブジェクト

    Quaternion beforeFrameRotation;

    Vector3 offset;//カメラとプレイヤーの相対距離

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        beforeFrameRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        beforeFrameRotation = transform.rotation;
        //プレイヤーが設定されていない場合は処理をしない
        if (player == null)
        {
            return;
        }

        transform.position = player.transform.position + offset;

        if(PlayerController.GetPlayerState() == PlayerState.SLIP)
        {
            transform.rotation = beforeFrameRotation;
        }

    }
}
