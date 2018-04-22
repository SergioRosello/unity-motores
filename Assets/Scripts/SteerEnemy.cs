using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerEnemy : BehaviourController {
	public float enemyBounds = 1f;
	public float speedo = 2;
	private float rotationDirection;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		float x = Random.Range(0, 2) == 0 ? -PlayerController.widthOrtho : PlayerController.widthOrtho;
		rotationDirection = (x / PlayerController.widthOrtho);
		rb.position = new Vector2(x, Random.Range(-Camera.main.orthographicSize + enemyBounds, Camera.main.orthographicSize - enemyBounds));
	}
	
	float sadasd;
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		sadasd = rb.rotation-rotationDirection;
		rb.MoveRotation(sadasd);

		rb.MovePosition(transform.position - transform.up * speedo * Time.deltaTime);

		if(Vector2.Distance(transform.position, Vector2.zero) > 15) {
			Destroy(gameObject);
		}
	}

	protected override void DetermineDirection(){
	}
}
