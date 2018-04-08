using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager> {

	public Text scoreText;
	public static int score;
	
	void Awake(){		
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();	
	}
}
