﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoint : MonoBehaviour {

    public int coinScore;

    private ScoreManager scoreManager;

    public BtnFX btnfx;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        btnfx = FindObjectOfType<BtnFX>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            scoreManager.AddScore(coinScore);
            gameObject.SetActive(false);
            btnfx.GetCoinsSound();
        }
    }
}
