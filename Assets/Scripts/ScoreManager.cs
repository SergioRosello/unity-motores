using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager> {

	public Text scoreText;
	private int score = 0;
	
	// Use this for initialization
	void Start () {
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore(int scoreToAdd){
		Debug.Log("Score before: " + score);
		score =+ scoreToAdd;
		scoreText.text = score.ToString();
		Debug.Log("Score after: " + score);
	}
}
