﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : BehaviourController {

	public float timerBetweenBullets;
	public float playerBoundsY = 0.5f, playerBoundsX = 0.5f;
	public static float screenRatio;
	public static float widthOrtho;
	public GameObject bulletPrefab;
	public float bulletSpeed;
	private float timerBetweenBulletsAux = 0;
	public Text UIHealth;

	Animator animator;
	public AudioClip shot;
	private AudioSource audioSource;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		 screenRatio = Mathf.Abs((float)Screen.width / (float)Screen.height);
		 audioSource = GetComponent<AudioSource>();
		 widthOrtho = Camera.main.orthographicSize * screenRatio;
		 animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		keepPlayerWithinBounds();
		UIHealth.text = health.CurrentHealth.ToString();
		velocity = new Vector2(maxSpeed * horizontal, maxSpeed * vertical);
		timerBetweenBulletsAux += Time.deltaTime;
		if(Input.GetKey(KeyCode.Space) && timerBetweenBulletsAux >= timerBetweenBullets){
			timerBetweenBulletsAux = 0;
			var bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
			audioSource.clip = shot;
			audioSource.Play();
		}
		//TODO: Esto está mal necesita refactorización
		if(horizontal > 0){
			animator.SetBool("Right", true);
			animator.SetBool("Left", false);
		} else if(horizontal < 0) {
			animator.SetBool("Left", true);
			animator.SetBool("Right", false);
		} else {
			animator.SetBool("Right", false);
			animator.SetBool("Left", false);
		}
	}

	void Explosion(){
		Destroy(gameObject);
		if(!health.IsAlive){
			SceneManager.LoadScene("Death");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Health enemyhealth = other.GetComponent<Health>();
		if(enemyhealth) enemyhealth.CurrentHealth--;
		Destroy(other.gameObject);
		health.CurrentHealth--;
	}

	protected void keepPlayerWithinBounds(){
		// Keep player between upper bounds
		if(rb.position.y + playerBoundsY > Camera.main.orthographicSize){
			rb.position = new Vector2(rb.position.x, Camera.main.orthographicSize - playerBoundsY);
		}

		// Keep the player between right bounds
		if(rb.position.x + playerBoundsX > widthOrtho){
			rb.position = new Vector2(widthOrtho - playerBoundsX, rb.position.y);
		}
		
		// Keep player between lower bounds
		if(rb.position.y - playerBoundsY< -Camera.main.orthographicSize){
			rb.position = new Vector2(rb.position.x, -Camera.main.orthographicSize + playerBoundsY);
		}

		// Keep the player between left bounds
		if(rb.position.x - playerBoundsX < -widthOrtho){
			rb.position = new Vector2(-widthOrtho + playerBoundsX, rb.position.y);
		}
	}
	protected override void DetermineDirection(){
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
	}

	void OnDestroy(){
		PlayerPrefs.SetFloat("highscore", ScoreManager.highScore);
		PlayerPrefs.Save();
	}
}
