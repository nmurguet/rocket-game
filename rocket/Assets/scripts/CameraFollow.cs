using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Camera myCamera; 
	public Transform target; 
	public float speed; 
	public bool following; 

	public float offset_x; 
	public float offset_y; 

	public float zoom; 

	public float minZoom; 
	public float maxZoom; 

	public float maxSpeed; 


	public PlayerController playerController; 
	private Rocket player; 

	// Use this for initialization
	void Start () {
		
		myCamera = Camera.main; 
		playerController = FindObjectOfType<PlayerController> (); 


		following = true; 


		player = playerController.ReturnActivePlayer ().GetComponent<Rocket> (); 

		target = playerController.ReturnActivePlayer ().transform; 

		
	}


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.M)) {
			target = playerController.ReturnActivePlayer ().transform; 

		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (following) {
			Vector3 offset = new Vector3 (offset_x, offset_y, -10f);
			if (target) {
				transform.position = Vector3.Lerp (transform.position + offset, target.position, speed);

			}
		}

		if (player.velocity > maxSpeed) {
			myCamera.orthographicSize += 0.05f; 

		} else if (player.velocity < maxSpeed) {
			myCamera.orthographicSize -= 0.05f; 

		}
		if (myCamera.orthographicSize > maxZoom) {
			myCamera.orthographicSize = maxZoom; 

		}
		if (myCamera.orthographicSize < minZoom) {
			myCamera.orthographicSize = minZoom; 

		}

	}
}
