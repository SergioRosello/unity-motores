using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {

public float timeToDespawn = 5;
float spawnTime;
	private SpriteRenderer sr;
	private Rigidbody2D rb;
    Animator anim;

	void Awake() {
		StartCoroutine (DespawnCoroutine());
		sr = GetComponentInChildren<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
	}

	void Start () {
		sr.flipY = rb.velocity.x < 0;
	}

	private IEnumerator DespawnCoroutine() {
		yield return new WaitForSeconds(timeToDespawn);
		// Destroy (gameObject);
		PoolManager.Despawn(gameObject);
		yield return null;
	}

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == Layers.Enemies) {
			var targetHealth = other.GetComponent<Health>();
			if (targetHealth) {
				ScoreManager.score += 10;
				targetHealth.CurrentHealth--;
			}
			//Destroy(gameObject, 0f);
			PoolManager.Despawn(gameObject);
		}
	}	
}
