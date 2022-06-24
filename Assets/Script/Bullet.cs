
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int bulletSpeed = 30; 
	public int bulletDirection = 1;

	void FixedUpdate () {

		GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletDirection*0.1f*bulletSpeed, 0), ForceMode2D.Impulse);

	}


	void OnBecameInvisible() {  
		Destroy(gameObject);
	}


}