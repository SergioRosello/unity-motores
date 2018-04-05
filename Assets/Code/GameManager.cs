using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public GameObject basicEnemy;
	public Rigidbody2D rigidbody;
	void Start () {
		basicEnemy = GetComponent<GameObject>();
		PoolManager.Spawn(basicEnemy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
