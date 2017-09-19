using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	public GameObject left_rocket; 

	public GameObject right_rocket; 

	private Rigidbody2D rb; 

	public float thrust; 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();



	}


	void Movement()
	{
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForceAtPosition (left_rocket.transform.up * thrust, left_rocket.transform.position);


		}

		if (Input.GetKey (KeyCode.D)) {
			rb.AddForceAtPosition (right_rocket.transform.up * thrust, right_rocket.transform.position);


		}
		
	}

}
