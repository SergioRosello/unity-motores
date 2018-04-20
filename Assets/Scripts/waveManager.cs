using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float basicEnemySpawnRate;
	
	[Range(0.0f, 1.0f)]
	public float steerEnemySpawnRate;
    public List<GameObject> enemyTypes;
	private float bossTimer;
    public float bossEntrance;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

	protected void spawnEnemiesOfType(GameObject enemy, float spawnRate){
		if(Random.Range(0.0f,1.0f) <= spawnRate){
			PoolManager.Load(enemy);
			PoolManager.Spawn(enemy);
		}
	}

    protected void spawnEnemiesOfType(GameObject enemy){
        PoolManager.Load(enemy);
        PoolManager.Spawn(enemy);
    }

    void Update(){
        bossTimer += Time.deltaTime;
		if(!PauseMenu.GameIsPaused) {
			spawnEnemiesOfType(enemyTypes[0], basicEnemySpawnRate);
			spawnEnemiesOfType(enemyTypes[1], steerEnemySpawnRate);

            if (bossEntrance < bossTimer)
            {
                bossTimer = 0;
                spawnEnemiesOfType(enemyTypes[2]);
            }
		}
	}
}