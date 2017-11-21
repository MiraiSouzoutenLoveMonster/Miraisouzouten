using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    public ParticleSystem particle;     //パーティクル本体

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //エフェクト生成関数
    public ParticleSystem Create(Transform parent = null)
    {
        ParticleSystem ps;  //生成したパーティクルオブジェクト

        //親を明示的に指定していない場合はこの自分自身を親として生成する
        if (parent == null)
        {
            ps = Instantiate(particle, transform);
        }
        else
        {
            ps = Instantiate(particle, parent);
        }
        
        return ps;
    }
}
