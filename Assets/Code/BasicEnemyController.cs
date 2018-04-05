using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MovementController {
	// Use this for initialization
	protected override void Start () {
		base.Start();
		// rb.position = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0, Screen.width), Screen.height + 3));
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		velocity = new Vector2(0, -maxSpeed);
		Debug.Log("velocity: " + velocity);
	}

	protected override void DetermineDirection(){
	}
}
