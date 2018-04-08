using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {

	public List<GameObject> Wave;
	// Use this for initialization
	void Start () {
		PoolManager.Load(Wave[0], Wave.Count);
		foreach( GameObject enemy in Wave) {
			PoolManager.Spawn(enemy);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
