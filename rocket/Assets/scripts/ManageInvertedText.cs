using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class ManageInvertedText : MonoBehaviour {

	public Text inverted;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt ("inverted") == 0) {
			inverted.text = "Inverted Controls: Off";

		} else if (PlayerPrefs.GetInt ("inverted") == 1) {
			inverted.text = "Inverted Controls: On";

		}
		
	}
}
