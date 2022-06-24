using UnityEngine;
using System.Collections;

public class alienController : MonoBehaviour {


	public float enemySpeed = 0.1f;
	public GameObject alienBullet;

	//Bullets related stuff
	private float timeLastShot;
	private float alienBulletXOffset = -0.1f;
	private float alienBulletYOffset = -0.02f;
	private float timeBetweenBullets = 0.5f; 
	private int bulletCounter = 0;
	private int bulletsPerSeries = 3; 
	private float timeBetweenShotsSeries; 
	private float timingShotSeries;
	private bool canShoot = false;


	void Start () {

		GetComponent<Collider2D>().enabled = false;

		timeBetweenShotsSeries = bulletsPerSeries * timeBetweenBullets + 3;

		transform.position = new Vector3(Random.Range(2.45f, 4f), Random.Range(-1.70f, 0.44f), transform.position.z);

	}

	void FixedUpdate () {

		GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.1f*enemySpeed, 0), ForceMode2D.Impulse);

		if (canShoot && Time.time >= timeLastShot && bulletCounter < bulletsPerSeries) {
			Instantiate(alienBullet, transform.position+new Vector3 (alienBulletXOffset,alienBulletYOffset,0), Quaternion.identity);
			timeLastShot = Time.time + timeBetweenBullets;
			bulletCounter++;
		} 

		if (Time.time >= timingShotSeries) {
			bulletCounter=0;
			timingShotSeries = Time.time + timeBetweenShotsSeries;
		} 

	}


	void OnBecameVisible() {  

		if (alienBullet!=null) {
			canShoot = true;
		}

		GetComponent<Collider2D>().enabled = true;
	}



	void OnBecameInvisible() {  
		Destroy(gameObject);
	}


	void OnTriggerEnter2D(Collider2D thisObject)
	{
		Camera.main.GetComponent<GUI>().currentScore++;
		StartCoroutine(blinkUponCollisionAndDestroy(gameObject));

	}


	IEnumerator blinkUponCollisionAndDestroy(GameObject thisPlayer)
	{
		thisPlayer.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
		yield return new WaitForSeconds(0.1f);
		Destroy(gameObject);
	}

}