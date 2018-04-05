using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager> {
	public GameObject basicEnemyPrefab;
	// Use this for initialization
	void Start () {
		PoolManager.Load(basicEnemyPrefab, 5);
	}
	
	public void SpawnParticles(GameObject prefab, Vector2 position){
		var go = PoolManager.Spawn(prefab);
		go.transform.position = position;
	}
}
