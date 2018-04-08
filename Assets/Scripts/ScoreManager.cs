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
	void Start(){
		DontDestroyOnLoad(this);
	}
	void Update () {
		scoreText.text = score.ToString();	
	}
}
