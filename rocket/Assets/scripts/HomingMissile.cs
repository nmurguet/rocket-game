using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

	public float speed = 5f; 
	public float rotatingSpeed = 200f; 
	private GameObject target; 

	public GameObject deathEffect; 
	private Rigidbody2D rb; 
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player"); 
		rb = GetComponent<Rigidbody2D> (); 
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


	void FixedUpdate(){
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position; 

		point2Target.Normalize (); 

		float value = Vector3.Cross (point2Target, transform.right).z;

		rb.angularVelocity = rotatingSpeed * value; 
		rb.velocity = transform.right * speed; 

	}

	void OnTriggerEnter2D(Collider2D other)
	{ if (other.tag == "Player") {
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (rb.velocity.x * 10f, rb.velocity.y * 10f);
			//other.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 800f);
			Destroy (this.gameObject, 0.02f);
		} else {
		     Destroy (this.gameObject, 0.02f);
			Instantiate (deathEffect, transform.position, Quaternion.identity);
		}

	}
}
