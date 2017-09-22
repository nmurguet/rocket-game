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

	public float HighScore; 
	public float timeToDisplay; 

	public GameObject winPanel; 
	public Text textHighscore; 
	public Text textYourTime; 



	public bool isPaused; 






	// Use this for initialization
	void Start () {

		player = FindObjectOfType<Rocket> (); 
		store_timer = timer; 
		textTimer.enabled = false; 
		time = 0; 
		isPaused = false; 

		winPanel.SetActive (false);

		if (PlayerPrefs.HasKey (SceneManager.GetActiveScene ().name) == false) {
			PlayerPrefs.SetFloat (SceneManager.GetActiveScene ().name, 9999f);

		} else {
		}
		HighScore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);

		
	}

	// Update is called once per frame
	void Update () {


		if (isPaused) {
			Time.timeScale = 0;
		} else
			Time.timeScale = 1; 
		

		if (player.timeStart && !isPaused) {
			time += Time.deltaTime; 
		}

		textTimeLvl.text = time.ToString("F2"); 

		if (player.clear_level) {
			
			timer -= Time.deltaTime; 
			textTimer.text = timer.ToString("F2"); 
			textTimer.enabled = true; 
			if (timer < 0.01f) {
				isPaused = true; 
				timer = 0f;
				//SceneManager.LoadScene (lvl);
				winPanel.SetActive(true); 
				if (time < PlayerPrefs.GetFloat (SceneManager.GetActiveScene ().name)) {
					
					HighScore = time;
					timeToDisplay = time; 
					PlayerPrefs.SetFloat (SceneManager.GetActiveScene ().name, HighScore);

				} else {
					HighScore = PlayerPrefs.GetFloat (SceneManager.GetActiveScene ().name);
					timeToDisplay = time; 


				}
				textHighscore.text = "Best Time: " + HighScore.ToString("F2");
				textYourTime.text = "Your Time: " + timeToDisplay.ToString ("F2");


			}

		} else {
			timer = store_timer; 
			textTimer.enabled = false; 

		}
		
	}
}
