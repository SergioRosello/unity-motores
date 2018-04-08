using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {

	public List<GameObject> wave0;
	public List<GameObject> wave1;
	private List<List<GameObject>> waves;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		Debug.Log("Hola!!");
		waves  = new List<List<GameObject>>();
		waves.Add(wave0);
		waves.Add(wave1);
		Debug.Log("Hola - 2!!");
	}
	void Update(){
		Debug.Log("Waves.count -> " + waves.Count);
		while(waves.Count > 0){
			if(waves[0].Count == 0){
				waves.Remove(waves[0]);
			}
			spwanWave(waves[0]);
		}
		
	}
	protected void spwanWave(List<GameObject> wave){
		PoolManager.Load(wave[0], wave.Count);
		foreach( GameObject enemy in wave) {
			PoolManager.Spawn(enemy);
		}
	}
}
