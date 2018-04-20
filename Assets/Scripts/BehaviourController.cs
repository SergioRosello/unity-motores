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

	private PlayerController playrC;
	
	protected abstract void DetermineDirection();
	// Use this for initialization
	virtual protected void Start () {
		rb = GetComponent<Rigidbody2D>();
		health = GetComponent<Health>();
		playrC = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	virtual protected void Update () {
		DetermineDirection();
		CheckHealth();
	}

	virtual protected void CheckHealth(){

		if(!health.IsAlive)
		{
			if(playrC) {
				Destroy(gameObject, 3f);
			} else {
				PoolManager.Despawn(gameObject);
				// Destroy(gameObject);
			}
		}
	}
	
	virtual protected void LateUpdate(){
		rb.velocity = velocity;
	}

}
