using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Titlescreen : MonoBehaviour {




	public string level;
	// Use this for initialization



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void StartLevel()
	{
		SceneManager.LoadScene (level);


	}

	public void LevelSelect(string lvl)
	{
		SceneManager.LoadScene (lvl);
	}


	public void RestartLevel()
	{
		Scene scene = SceneManager.GetActiveScene();

		SceneManager.LoadScene (scene.name);

	}


	public void QuitGame()
	{

		Application.Quit (); 
	}


	public void ResetPlayerPrefs()
	{
		
			PlayerPrefs.DeleteAll();


	}

	public void InvertControls()
	{
		if (PlayerPrefs.GetInt ("inverted") == 0) {
			PlayerPrefs.SetInt ("inverted", 1);

		} else if (PlayerPrefs.GetInt ("inverted") == 1) {
			PlayerPrefs.SetInt ("inverted", 0);

		}

	}








}
