using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Transform start; 
	public Transform stop; 
	public float speed; 
	public bool done; 

	// Use this for initialization
	void Start () {
		done = true; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		float step = speed * Time.deltaTime; 
		if (done == false) {

			transform.position = Vector3.MoveTowards (transform.position, stop.position, step);

			if (transform.position == stop.position) {
				done = true; 

			}

		} else if (done == true) {

			transform.position = Vector3.MoveTowards (transform.position, start.position, step);
			if (transform.position == start.position) {
				done = false; 

			}
		}

	



	}
}
