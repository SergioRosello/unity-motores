using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float basicEnemySpawnRate;
	
	[Range(0.0f, 1.0f)]
	public float steerEnemySpawnRate;
	public List<GameObject> enemyTypes;
	private float time;
	private int wave;
	private bool wave0;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		wave0 = true;
	}

	protected void spawnEnemiesOfType(GameObject enemy, float spawnRate){
		if(Random.Range(0.0f,1.0f) <= spawnRate){
			PoolManager.Load(enemy);
			PoolManager.Spawn(enemy);
		}
	}
	void Update(){
		
		if(!PauseMenu.GameIsPaused) {
			spawnEnemiesOfType(enemyTypes[0], basicEnemySpawnRate);
			spawnEnemiesOfType(enemyTypes[1], steerEnemySpawnRate);		
			// StartCoroutine("enemyWaveManager");
		}
	}

	// IEnumerator enemyWaveManager(){
	// 	spawnEnemiesOfType(enemyTypes[0], basicEnemySpawnRate);
	// 	spawnEnemiesOfType(enemyTypes[1], steerEnemySpawnRate);
	// 	yield return new WaitForSeconds(10);
	// }
}