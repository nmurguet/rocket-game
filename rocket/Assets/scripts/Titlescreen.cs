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





}
