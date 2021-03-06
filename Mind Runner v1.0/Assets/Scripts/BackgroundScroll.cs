﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    Material material;
    Vector2 offset;

    public float xVelocity, yVelocity;

    public void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Use this for initialization
    void Start () {
        offset = new Vector2(xVelocity, yVelocity);
	}
	
	// Update is called once per frame
	void Update () {
        //Scrolling background texture
        material.mainTextureOffset += offset * Time.deltaTime;
	}
}
