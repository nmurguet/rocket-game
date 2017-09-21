using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
	public Rigidbody2D rb; 
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		rb.angularVelocity = -15f;
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.angularVelocity = -15f;
	}
}
