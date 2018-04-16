using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : BehaviourController {
	public float enemyBounds = 1f;
	public float speed = 2f;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		rb.position = new Vector2(Random.Range(-PlayerController.widthOrtho + enemyBounds, PlayerController.widthOrtho - enemyBounds),Camera.main.orthographicSize);
		speed = -maxSpeed;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();

		if(rb.position.y <= -Camera.main.orthographicSize + enemyBounds){
			rb.MoveRotation(180f);
			speed = maxSpeed;
		}
		velocity = new Vector2(0, speed);

		if(Vector2.Distance(transform.position, Vector2.zero) > 15) {
			Destroy(gameObject);
		}
	}

	protected override void DetermineDirection(){
	}
}
