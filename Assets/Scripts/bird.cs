﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

	public float UpForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;

	public AudioClip FlyAudio;
	public AudioClip DieAudio;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isDead == false) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, UpForce));
				anim.SetTrigger ("Flap");

				GetComponent<AudioSource> ().PlayOneShot (FlyAudio);
			}
		}
	}

	void OnCollisionEnter2D()
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.GameOver ();

		GetComponent<AudioSource> ().PlayOneShot (DieAudio);
	}
}
