using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager> {

	public Text scoreText;
	public Text highScoreText;
	public static int score;
	public static int highScore;
	
	void Awake(){
		score = 0;
		if(PlayerPrefs.HasKey("highscore")){
			highScore = (int)PlayerPrefs.GetFloat("highscore", 0);
		}
	}
	
	void Update () {
		scoreText.text = score.ToString();
		highScoreText.text = highScore.ToString();
		if(score > highScore){
			highScore = score;
		}
		
	}
}
