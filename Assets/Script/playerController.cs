

using UnityEngine;
using System.Collections;


public class playerController : MonoBehaviour {

	public GameObject playerBullet;
	public bool playerIsImmortal = false; 
	public int playerLives = 3; 
	public bool isGameOver = false; 
	private float pushUpForce = 6.0f; 
	private float playerBulletXOffset = 0.5f;
	private float playerBulletYOffset = 0f;
	private float timeBetweenShots = 0.2f;  
	private float timestamp;

	void FixedUpdate () {


		if (Input.GetButton("Fire1"))
		{
			Fire1Pressed ();

		}
		if (Input.GetButton("Fire2"))
		{
			Fire2Pressed ();
		}
	}

	void Fire1Pressed () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, pushUpForce));

	}

	void Fire2Pressed () {

		if (Time.time >= timestamp) {
			Instantiate(playerBullet, transform.position+new Vector3 (playerBulletXOffset,playerBulletYOffset,0), Quaternion.identity);
			timestamp = Time.time + timeBetweenShots;
		}
	}
	
	void OnTriggerEnter2D(Collider2D thisObject)
	{
		playerDidCollide ();
	}

	
	void OnCollisionEnter2D(Collision2D thisObject)
	{
		playerDidCollide ();
	}



	void playerDidCollide () {

		if (playerLives > 0 && !playerIsImmortal) {
			playerLives=playerLives-1; 
			

		} else if (playerLives <= 0 && !playerIsImmortal) { 

			gameOver();

		}


	}


	void gameOver () {

		//Debug.Log("GAME OVER");
		isGameOver = true; // This is picked by the Update function in GUI.cs
		Time.timeScale = 0.0F; // Stop the game

	}

	// NB. Update is not affected by Time.timeScale (i.e. it also works during Game Over)
	void Update () {

		// NB Input.GetMouseButtonDown(0) not only triggers on the left mouse click, but also iOS & Android touch events 
		if (isGameOver && Input.GetButtonDown("Fire1") || isGameOver && Input.GetMouseButtonDown(0)) {
			//Debug.Log("GAME RESTART");
			Time.timeScale = 1.0F; // Restart the time
			Application.LoadLevel(Application.loadedLevel); // Reload this level
		}

	}


}