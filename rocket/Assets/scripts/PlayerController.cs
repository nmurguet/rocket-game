using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public List<GameObject> players;

	public int activePlayer; 

	// Use this for initialization
	void Awake () {
		if (!PlayerPrefs.HasKey ("activePlayer")) {
			PlayerPrefs.SetInt ("activePlayer", 0);

		}

		activePlayer = PlayerPrefs.GetInt ("activePlayer");

		players [activePlayer].SetActive (true); 

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.V)) {

			PlayerPrefs.SetInt ("activePlayer", 0);
		
		}
		if (Input.GetKey (KeyCode.B)) {

			PlayerPrefs.SetInt ("activePlayer", 1);
		}
		
	}



	public void RocketLeft()
	{
		players [activePlayer].GetComponent<Rocket> ().RocketLeft();

	}

	public void UnpressedRocketLeft()
	{
		players [activePlayer].GetComponent<Rocket> ().UnpressedRocketLeft();
	}

	public void RocketRight()
	{
		players [activePlayer].GetComponent<Rocket> ().RocketRight();
	}

	public void UnpressedRocketRight()
	{
		players [activePlayer].GetComponent<Rocket> ().UnpressedRocketRight();
	}

	public GameObject ReturnActivePlayer()
	{

		return players [activePlayer];

	}
}
