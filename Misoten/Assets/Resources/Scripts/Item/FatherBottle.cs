using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherBottle : Item {

    public MeshRenderer render;
    public float effectPower;
    public float EffectTime;
    public Effect particle;  //このアイテムを取得した時のエフェクトオブジェクト

    float countTime;

    PlayerController player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!render.enabled)
        {
            countTime += Time.deltaTime;

            if (countTime >= EffectTime)
            {
                player.SetPlayerEffectiveSpeed(0);

                Destroy(gameObject);

                return;
            }
        }
    }

    public override void Effect()
    {

    }

    public override void Effect(PlayerController targetPlayer)
    {
        player = targetPlayer;
        player.SetPlayerEffectiveSpeed(-effectPower);

        render.enabled = false;

        countTime = 0.0f;

        //CutInManager.CreateCutIn(1, player.GetPlayerNumber());

        particle.Create(player.transform);
    }
}
