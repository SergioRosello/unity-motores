using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour {

	public List<GameObject> wave0;
	public List<GameObject> wave1;
	// Use this for initialization
	void Start () {
		spwanWave(wave0);
	}
	protected void spwanWave(List<GameObject> wave){
		PoolManager.Load(wave[0], wave.Count);
		foreach( GameObject enemy in wave) {
			PoolManager.Spawn(enemy);
		}
	}
}
