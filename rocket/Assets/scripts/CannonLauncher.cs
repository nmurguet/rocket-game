using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour {

	public GameObject bullet; 
	public GameObject spawnBullet; 

	public GameObject activeBullet; 

	// Use this for initialization
	void Start () {
		Instantiate (bullet, spawnBullet.transform.position, Quaternion.identity);
		activeBullet = GameObject.FindGameObjectWithTag ("homingMissile");
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if (activeBullet.GetComponent<HomingMissile> ().isDestroyed == true) {
			StartCoroutine( WaitandShoot (2));
					
			}




	}


	IEnumerator WaitandShoot(int seconds)
	{
		yield return new WaitForSeconds (seconds);
		activeBullet.GetComponent<HomingMissile> ().Shoot (spawnBullet.transform);

	}
}
