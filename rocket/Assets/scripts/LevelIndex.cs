using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class LevelIndex : MonoBehaviour {

	public int activePage; 

	public int lastPage;

	public int firstPage; 

	public List<GameObject> pages; 





	// Use this for initialization
	void Start () {
		activePage = 0;
		lastPage = pages.Count -1; 
		firstPage = 0; 
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			ChangePageBack ();

		}
		if (Input.GetKeyDown (KeyCode.D)) {
			ChangePageForward ();

		}

		
	}

	public void ChangePageForward()
	{
		if (activePage < lastPage) {
			
			pages [activePage].SetActive (false); 
			activePage += 1;
			pages [activePage].SetActive (true);
		}


	}

	public void ChangePageBack()
	{
		if (activePage > firstPage) {

			pages [activePage].SetActive (false); 
			activePage -= 1;
			pages [activePage].SetActive (true);
		}


	}
}
