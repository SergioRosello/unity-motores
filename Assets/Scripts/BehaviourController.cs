using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourController : MonoBehaviour {

	public float maxSpeed = 5f;
	protected float horizontal;
	protected float vertical;
	protected Rigidbody2D rb;
	protected Vector2 velocity;
	protected Health health;
	
	protected abstract void DetermineDirection();
	// Use this for initialization
	virtual protected void Start () {
		rb = GetComponent<Rigidbody2D>();
		health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	virtual protected void Update () {
		DetermineDirection();
		CheckHealth();
	}

	virtual protected void CheckHealth(){
		if(!health.IsAlive){
			Destroy(gameObject, 0f);
		}
	}
	
	virtual protected void LateUpdate(){
		rb.velocity = velocity;
	}

}
