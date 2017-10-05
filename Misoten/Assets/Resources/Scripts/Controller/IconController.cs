using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Color color = Color.white;

	// Use this for initialization
	void Start () {
        spriteRenderer.sprite = sprite;
        spriteRenderer.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
