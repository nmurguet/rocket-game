using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SelectPlayer : MonoBehaviour {

	public Button left;
	public Button right; 

	public Image sr; 

	public int activePlayer; 
	public int max_player;
	public int index; 

	public List<GameObject> players; 


	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("activePlayer")) {
			PlayerPrefs.SetInt ("activePlayer", 0);

		}

		activePlayer = PlayerPrefs.GetInt ("activePlayer"); 
		index = activePlayer; 
	}
	
	// Update is called once per frame
	void Update () {
		if (index == 0) {
			sr.color = Color.white; 
		} else if (index == 1) {
			sr.color = Color.red; 
		} else if (index == 2) {
			sr.color = Color.green;
		} else {
			sr.color = Color.blue; 
		}
	}


	public void LeftPress()
	{
		index = (index+players.Count-1)%players.Count; 
		PlayerPrefs.SetInt ("activePlayer", index);
	}

	public void RightPress()
	{
		index = (index+1)%players.Count; 
		PlayerPrefs.SetInt ("activePlayer", index);
	}


}
