
using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GUI : MonoBehaviour {

	public int currentScore = 0; 
	public bool isGameOver;
	public int playerLives; 

	private Text livesText;
	private Text scoreText;
	private Text gameOverText;

	void Start () {

		livesText = GameObject.Find("Lives").GetComponent<Text>();
		scoreText = GameObject.Find("Score").GetComponent<Text>();
		gameOverText = GameObject.Find("GameOver").GetComponent<Text>(); 

	}

	void Update () {

		playerLives = GameObject.Find("Player").GetComponent<playerController>().playerLives;
		isGameOver = GameObject.Find("Player").GetComponent<playerController>().isGameOver;

		livesText.text = "Joon: "+playerLives;
		scoreText.text = "Emtiaz: "+currentScore;

		if (isGameOver) {
			gameOverText.enabled = true;
		}
	}
}