using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeterController : MonoBehaviour {

    public SoundMeterImageController[] SMI;//音量バーのオブジェクト。小さい順に入れる

    public float volume;//ボリューム。publicなのはデバッグ用

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        int countDraw = 0;

		for(int i = 0; i < SMI.Length; i++)
        {
            if(SMI[i].SetIsDraw(volume))
            {
                countDraw++;
            }
        }

        //ボリュームがMAXに対してどのくらいの割合
        //であるかを基準としてメーターの色を決める
        //赤、黄色、緑の三色を使用する
        float per = (float)countDraw / (float)SMI.Length;//割合を計算

        Color imageColor;

        //一定以下の割合なら赤色を設定
        if(per < 1.0f / 3.0f)
        {
            imageColor = Color.red;
        }
        else if(per < 2.0f / 3.0f)
        {
            imageColor = Color.yellow;
        }
        else
        {
            imageColor = Color.green;
        }

        for (int i = 0; i < countDraw; i++)
        {
            SMI[i].SetColor(new Vector3(imageColor.r,imageColor.g,imageColor.b));
        }
	}
}
