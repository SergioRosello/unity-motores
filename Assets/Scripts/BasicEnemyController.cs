using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MovementController {
	public float enemyBounds = 1f;
	private Health Health;
	public float speed = 2f;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		Health = GetComponent<Health>();
		Debug.Log("PlayerControllerWithOrto: " + PlayerController.widthOrtho.ToString());
		rb.position = new Vector2(Random.Range(-PlayerController.widthOrtho, PlayerController.widthOrtho),Camera.main.orthographicSize);
		speed = -maxSpeed;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		Debug.Log("Health.isAlive() -> " + Health.IsAlive);
		if(!Health.IsAlive){
			Destroy(gameObject, 0f);
		}
		if(rb.position.y <= -Camera.main.orthographicSize + enemyBounds){
			rb.MoveRotation(180f);
			speed = maxSpeed;
		}
		velocity = new Vector2(0, speed);
	}

	protected override void DetermineDirection(){
	}
}
