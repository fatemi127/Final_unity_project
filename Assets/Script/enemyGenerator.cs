
using UnityEngine;
using System.Collections;


public class enemyGenerator : MonoBehaviour {

	public GameObject alien;

	private float timeBetweenEnemies = 2f;  
	private int secondsBeforeFirstEnemyAppears = 1;

	private float timeLastAlien;


	void FixedUpdate () {

		if (Time.realtimeSinceStartup > secondsBeforeFirstEnemyAppears && Time.time >= timeLastAlien) {

		GameObject.Instantiate(alien);
		timeLastAlien = Time.time + timeBetweenEnemies;

		}
	}
}