using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Alpha : MonoBehaviour
{
    public Image image;
    [Range(0.1f, 3.0f)]
    public float defaultSpeed;  // 初期速度
    [Range(0.1f, 3.0f)]
    public float eventSpeed;    // イベント時の速度
    float speed;                // 現在の速度
    Color color;                // わかる

    // Use this for initialization
    void Start()
    {
        speed = 1.0f / (60 * defaultSpeed);
        color = image.color;

        speed *= -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        color.a += speed;       // α更新
        image.color = color;    // 色代入

        // イベント
        if (Input.GetKeyDown(KeyCode.Return))
        {
            speed = 1.0f / (60 * eventSpeed);
        }

        // 制限
        if (color.a >= 1.0f || color.a <= 0.0f)
        {
            speed *= -1.0f;
        }
    }
}
