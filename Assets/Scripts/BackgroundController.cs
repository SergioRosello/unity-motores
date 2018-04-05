using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	// Use this for initialization
	private Transform transform;
	private Vector3 velocity;
	public float mapSpeed = 5f;
	void Start () {
		transform = GetComponent<Transform>();
		velocity = new Vector3(0f, mapSpeed, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += -velocity * Time.fixedDeltaTime;
	}
}
