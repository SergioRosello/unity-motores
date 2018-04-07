using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {

public float timeToDespawn = 5;
float spawnTime;
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
			Debug.Log("Enemy has been beaten!");
			var targetHealth = other.GetComponent<Health> ();
			if (targetHealth) {
				targetHealth.CurrentHealth--;
			}
			else if(targetHealth.CurrentHealth <= 0){
				Destroy(other, 0f);
			}
			//SpawnerManager.Instance.SpawnParticles (SpawnerManager.Instance.BloodPrefab, transform.position);
		}
	}	
}
