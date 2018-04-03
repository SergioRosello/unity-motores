using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementController : MonoBehaviour {

	public float maxSpeed = 5f;
	protected float horizontal;
	protected float vertical;
	protected Rigidbody2D rb;
	protected Vector2 velocity;
	
	protected abstract void DetermineDirection();
	
	// Use this for initialization
	virtual protected void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	virtual protected void Update () {
		DetermineDirection();
	}

	virtual protected void LateUpdate(){
		rb.velocity = velocity;
	}
}
