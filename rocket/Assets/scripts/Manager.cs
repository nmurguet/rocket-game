using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Manager : MonoBehaviour {

	private Rocket player; 



	public float timer; 
	private float store_timer; 

	public string lvl;

	public Text textTimer; 


	public float time; 
	public Text textTimeLvl; 








	// Use this for initialization
	void Start () {

		player = FindObjectOfType<Rocket> (); 
		store_timer = timer; 
		textTimer.enabled = false; 
		time = 0; 

		
	}

	// Update is called once per frame
	void Update () {
		

		if (player.timeStart) {
			time += Time.deltaTime; 
		}

		textTimeLvl.text = time.ToString("F2"); 

		if (player.clear_level) {
			
			timer -= Time.deltaTime; 
			textTimer.text = timer.ToString("F2"); 
			textTimer.enabled = true; 
			if (timer < 0.01f) {
				timer = 0f;
				SceneManager.LoadScene (lvl);

			}

		} else {
			timer = store_timer; 
			textTimer.enabled = false; 

		}
		
	}
}
