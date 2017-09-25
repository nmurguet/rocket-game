using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Transform start; 
	public Transform stop; 
	public float speed; 
	public bool done; 

	public List<GameObject> platforms; 

	public int activePlatform;

	// Use this for initialization
	void Start () {
		done = true; 

		activePlatform = 0; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		/*
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

	*/



	}
	void Update()
	{
		MultiplePlatforms (); 

	}


	void MultiplePlatforms()
	{
		float step = speed * Time.deltaTime; 
		transform.position = Vector3.MoveTowards (transform.position, platforms[activePlatform].transform.position, step);
		if (transform.position ==  platforms[activePlatform].transform.position) {
			if (activePlatform == platforms.Count -1) {
				activePlatform = 0; 

			} else if (activePlatform < platforms.Count-1){
				activePlatform += 1;

			}


		}

	}
}
