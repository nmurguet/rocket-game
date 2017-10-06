using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Rocket : MonoBehaviour{

	public GameObject left_rocket; 

	public GameObject right_rocket; 

	private Rigidbody2D rb; 

	public float thrust; 

	//groundeck stuff

	public Transform groundCheckPoint; 
	public bool isGrounded; 
	public float groundCheckRadius; 
	public LayerMask whatIsGround;

	public float velocity; 
	public bool clear_level; 

	//emitters
	public ParticleSystem left_emitter; 
	public ParticleSystem right_emitter; 


	//buttons

	private bool isPressedRight; 
	private bool isPressedLeft; 

	public bool timeStart; 


	//for planetoid levels
	private Vector2 dir; 
	private Transform target; 
	public float pullForce; 
	public bool pulled; 
	private float storeGrav;


	//check for inverted controls
	private int isInverted; //0 false - 1 true

	//death Particle
	public GameObject DeathParticle; 
	private SpriteRenderer sr; 


	//spawn point
	private Transform spawn; 


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> (); 
		spawn = GameObject.FindGameObjectWithTag ("spawn").transform; 
		transform.position = new Vector3 (spawn.position.x, spawn.position.y, spawn.position.z); 
		transform.rotation = spawn.rotation; 
		isPressedLeft = false; 
		isPressedRight = false; 
		clear_level = false; 
		timeStart = false; 
		if (!PlayerPrefs.HasKey ("inverted")) {
			PlayerPrefs.SetInt ("inverted", 0);

		}
		isInverted = PlayerPrefs.GetInt ("inverted");
		
	}
	
	// Update is called once per frame
	void Update () {

		if (pulled) {
			ManageGravity (); 

		}



		if (Input.GetKeyUp (KeyCode.R)) {
			Scene scene = SceneManager.GetActiveScene();

			SceneManager.LoadScene (scene.name);

		}



		Movement ();



	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, whatIsGround);
		velocity = Mathf.Abs (rb.velocity.x) + Mathf.Abs(rb.velocity.y);

		if (velocity < 0.1f && isGrounded) {
			clear_level = true; 

		} else {clear_level = false; 
		}
	}


	void Movement()
	{
		if (Input.GetKey (KeyCode.Q) || isPressedLeft) {
			rb.AddForceAtPosition (left_rocket.transform.up * thrust, left_rocket.transform.position);
			left_emitter.Play ();
			timeStart = true; 


		}

		if (Input.GetKey (KeyCode.P)|| isPressedRight) {
			rb.AddForceAtPosition (right_rocket.transform.up * thrust, right_rocket.transform.position);
			right_emitter.Play (); 
			timeStart = true; 

		}

		if (Input.GetKeyUp (KeyCode.Q)) {
			left_emitter.Stop ();


		}

		if (Input.GetKeyUp (KeyCode.P)) {
			
			right_emitter.Stop (); 

		}





		if (Input.GetKey (KeyCode.W)) {
			rb.AddForceAtPosition (right_rocket.transform.up * thrust, right_rocket.transform.position);
			rb.AddForceAtPosition (left_rocket.transform.up * thrust, left_rocket.transform.position);

		}
		
	}




	public void RocketLeft()
	{
		if (isInverted==0) {

		isPressedLeft = true; 
		left_emitter.Play ();
		}else if (isInverted == 1) {
			isPressedRight = true; 
			right_emitter.Play (); 
			Debug.Log ("Invertido");
		}

	}

	public void UnpressedRocketLeft()
	{
		if (isInverted == 0) {
			isPressedLeft = false; 
			left_emitter.Stop ();
		} else if (isInverted == 1) {
			isPressedRight = false; 
			right_emitter.Stop ();
		}


	}

	public void RocketRight()
	{
		if (isInverted==0) {
			isPressedRight = true; 
			right_emitter.Play (); 
		}else if (isInverted == 1) {		
			isPressedLeft = true; 
			left_emitter.Play ();
		}

	}

	public void UnpressedRocketRight()
	{
		if (isInverted==0) {
			isPressedRight = false; 
			right_emitter.Stop ();
		}else if (isInverted == 1) {
			isPressedLeft = false; 
			left_emitter.Stop ();
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "moving_platform") {
			transform.parent = other.transform;

		} else {
			transform.parent = null;
		}

	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "moving_platform") {
			/*float time = 0.5f;
			time -= Time.deltaTime;
			if (time < 0f) {
				transform.parent = null;
			}
*/
			StartCoroutine (WaitandRelease(1));
		} 

	}

	IEnumerator WaitandRelease(int seconds)
	{
		yield return new WaitForSeconds (seconds);
		transform.parent = null; 

	}

	IEnumerator WaitandRestart(int seconds)
	{
		yield return new WaitForSeconds (seconds);
		Scene scene = SceneManager.GetActiveScene();

		SceneManager.LoadScene (scene.name);

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "planet") {
			storeGrav = rb.gravityScale; 
			target = other.gameObject.transform;
			rb.gravityScale = 0; 
			pulled = true; 

		}


	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "planet") {
			 
			rb.gravityScale = 0.2f; 
			pulled = false; 
		}


	}

	void ManageGravity()
	{
		dir = transform.position - target.transform.position; 

		rb.AddForce (-dir.normalized * pullForce); 




	}



	void OnCollisionEnter2D(Collision2D other)
	{
		if (velocity > 4f) {
			
			sr.enabled = false; 
			Instantiate (DeathParticle, transform.position, Quaternion.identity);
			StartCoroutine(WaitandRestart(1));

		} 

	}



}
