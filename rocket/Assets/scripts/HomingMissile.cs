using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

	public float speed = 5f; 
	public float rotatingSpeed = 200f; 
	private GameObject target; 

	public GameObject deathEffect; 
	private Rigidbody2D rb; 
	public bool isDestroyed; 

	//variables for storing
	private float storeSpeed;
	private SpriteRenderer sr; 
	private bool isTargeting; 
	private TrailRenderer tr; 
	private CapsuleCollider2D cc;


	public PlayerController playerController; 
	private Rocket player; 

	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<PlayerController> (); 
		target = playerController.ReturnActivePlayer ().gameObject; 

		rb = GetComponent<Rigidbody2D> (); 
		tr = GetComponent<TrailRenderer> ();
		cc = GetComponent<CapsuleCollider2D> (); 
		isDestroyed = false; 
		storeSpeed = speed; 
		sr = GetComponent<SpriteRenderer> ();
		isTargeting = true; 
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


	void FixedUpdate(){
		if (isTargeting) {
			Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position; 

			point2Target.Normalize (); 

			float value = Vector3.Cross (point2Target, transform.right).z;

			rb.angularVelocity = rotatingSpeed * value; 
			rb.velocity = transform.right * speed; 
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{ if (other.tag == "Player") {
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (rb.velocity.x * 10f, rb.velocity.y * 10f);
			rb.velocity = new Vector2 (0, 0);
			tr.enabled = false; 
			sr.enabled = false;
			isTargeting = false;
			cc.enabled = false; 

			Instantiate (deathEffect, transform.position, Quaternion.identity);
			//Destroy (this.gameObject, 0.02f);
			isDestroyed = true; 

		} else {
		     //Destroy (this.gameObject, 0.02f);
			rb.velocity = new Vector2 (0, 0);
			isDestroyed = true; 
			isTargeting = false;
			
			tr.enabled = false; 
			sr.enabled = false;
			cc.enabled = false; 
			
			
			Instantiate (deathEffect, transform.position, Quaternion.identity);
			
		}

	}

	public void Shoot(Transform spawn)
	{
		
		cc.enabled = true; 
		isTargeting = true; 
		transform.position = new Vector2 (spawn.position.x, spawn.position.y); 
		sr.enabled = true; 
		speed = storeSpeed; 
		isDestroyed = false; 
		tr.enabled = true; 


	}
}
