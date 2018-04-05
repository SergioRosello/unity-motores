using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {

float spawnTime, timeToDespawn = 5;
	private SpriteRenderer sr;
	private Rigidbody2D rb;

	void Awake() {
		StartCoroutine (DespawnCoroutine());
		sr = GetComponentInChildren<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		sr.flipY = rb.velocity.x < 0;
	}

	private IEnumerator DespawnCoroutine() {
		yield return new WaitForSeconds(timeToDespawn);
		Destroy (gameObject);
		yield return null;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == Layers.Enemies) {
			var targetHealth = other.GetComponent<Health> ();
			if (targetHealth) {
				targetHealth.CurrentHealth--;
			}
			//SpawnerManager.Instance.SpawnParticles (SpawnerManager.Instance.BloodPrefab, transform.position);
		}
	}	
}
