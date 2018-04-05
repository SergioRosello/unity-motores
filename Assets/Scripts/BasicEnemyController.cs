using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MovementController {
	public float enemyBounds = 1f;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		// rb.position = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0, Screen.width), Screen.height + 3));
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(rb.position.y <= -Camera.main.orthographicSize + enemyBounds){
			Debug.Log("IF");
			velocity = new Vector2(0, maxSpeed);
			rb.MoveRotation(180f);
		}else{
			Debug.Log("ELSE");
			velocity = new Vector2(0, -maxSpeed);
		}
	}

	protected override void DetermineDirection(){
	}
}
