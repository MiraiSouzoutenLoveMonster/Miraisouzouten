using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatherCutIn : CutIn {

    public Image cut;//フェードインさせる対象
    public Transform moveTarget;//フェードインの目標地点
    public float moveSpeed;//フェードイン・アウトするスピードの係数
    public float StayTime;//フェードインしてから待機する時間

    float countMoveTime;
    float countStayTime;
    Vector3 initPos;

    // Use this for initialization
    void Start () {
        countMoveTime = 0.0f;
        countStayTime = 0.0f;
        initPos = cut.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveAnimation();
    }

    void MoveAnimation()
    {
        countMoveTime += Time.deltaTime * moveSpeed;

        if (countMoveTime <= 0.0f)
        {
            Destroy(gameObject);
        }

        if (countMoveTime >= 1.0f)
        {
            countMoveTime = 1.0f;
            countStayTime += Time.deltaTime;
            if (countStayTime >= StayTime)
            {
                moveSpeed *= -1.0f;
            }
        }

        Vector3 newPos = Vector3.Lerp(initPos, moveTarget.position, countMoveTime);

        cut.transform.position = newPos;
    }
}
