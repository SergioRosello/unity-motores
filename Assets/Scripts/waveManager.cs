using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {

	public List<GameObject> wave0;
	public List<GameObject> wave1;
	private List<List<GameObject>> waves;
	private int numberOfEnemiesInWave = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		waves  = new List<List<GameObject>>();
		waves.Add(wave0);
		waves.Add(wave1);
		numberOfEnemiesInWave = wave0.Count;
		spawnWave(waves[0]);
	}
	protected void spawnWave(List<GameObject> wave){
		PoolManager.Load(wave[0], wave.Count);
		foreach( GameObject enemy in wave) {
			PoolManager.Spawn(enemy);
			numberOfEnemiesInWave--;
		}
	}
	void Update(){
		Debug.Log("waves[0].Count -> " + waves[0].Count);
		if(waves[0].Count == 0){
			waves.Remove(waves[0]);
			numberOfEnemiesInWave = waves[0].Count;
			Debug.Log("waves 0 " + waves[0].Count);
			spawnWave(waves[0]);
		}
	}
}
