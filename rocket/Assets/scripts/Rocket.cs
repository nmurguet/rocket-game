﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Rocket : MonoBehaviour{

	public GameObject left_rocket; 

	public GameObject right_rocket; 

	private Rigidbody2D rb; 

	public float thrust; 

	//groundeck stuff

	public Transform groundCheckPoint; 
	public bool isGrounded; 
	public float groundCheckRadius; 
	public LayerMask whatIsGround;

	public float velocity; 
	public bool clear_level; 

	//emitters
	public ParticleSystem left_emitter; 
	public ParticleSystem right_emitter; 


	//buttons

	private bool isPressedRight; 
	private bool isPressedLeft; 

	public bool timeStart; 



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		isPressedLeft = false; 
		isPressedRight = false; 
		clear_level = false; 
		timeStart = false; 
		
	}
	
	// Update is called once per frame
	void Update () {





		if (Input.GetKeyUp (KeyCode.R)) {
			Scene scene = SceneManager.GetActiveScene();

			SceneManager.LoadScene (scene.name);

		}



		Movement ();



	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, whatIsGround);
		velocity = Mathf.Abs (rb.velocity.x) + Mathf.Abs(rb.velocity.y);

		if (velocity < 0.1f && isGrounded) {
			clear_level = true; 

		} else {clear_level = false; 
		}
	}


	void Movement()
	{
		if (Input.GetKey (KeyCode.Q) || isPressedLeft) {
			rb.AddForceAtPosition (left_rocket.transform.up * thrust, left_rocket.transform.position);
			left_emitter.Play ();
			timeStart = true; 


		}

		if (Input.GetKey (KeyCode.P)|| isPressedRight) {
			rb.AddForceAtPosition (right_rocket.transform.up * thrust, right_rocket.transform.position);
			right_emitter.Play (); 
			timeStart = true; 

		}

		if (Input.GetKeyUp (KeyCode.Q)) {
			left_emitter.Stop ();


		}

		if (Input.GetKeyUp (KeyCode.P)) {
			
			right_emitter.Stop (); 

		}





		if (Input.GetKey (KeyCode.W)) {
			rb.AddForceAtPosition (right_rocket.transform.up * thrust, right_rocket.transform.position);
			rb.AddForceAtPosition (left_rocket.transform.up * thrust, left_rocket.transform.position);

		}
		
	}




	public void RocketLeft()
	{
		isPressedLeft = true; 
		left_emitter.Play ();
		Debug.Log ("pressed");

	}

	public void UnpressedRocketLeft()
	{
		isPressedLeft = false; 
		left_emitter.Stop ();

	}

	public void RocketRight()
	{
		isPressedRight = true; 
		right_emitter.Play (); 


	}

	public void UnpressedRocketRight()
	{
		isPressedRight = false; 
		right_emitter.Stop ();

	}

}
