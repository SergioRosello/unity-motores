using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : BehaviourController {

	public float timerBetweenBullets;
	public float playerBoundsY = 0.5f, playerBoundsX = 0.5f;
	public static float screenRatio;
	public static float widthOrtho;
	public GameObject bulletPrefab;
	public float bulletSpeed;
	private float timerBetweenBulletsAux = 0;

	Animator animator;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		 screenRatio = Mathf.Abs((float)Screen.width / (float)Screen.height);
		 widthOrtho = Camera.main.orthographicSize * screenRatio;
		 animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		keepPlayerWithinBounds();
		velocity = new Vector2(maxSpeed * horizontal, maxSpeed * vertical);
		timerBetweenBulletsAux += Time.deltaTime;
		if(Input.GetKey(KeyCode.Space) && timerBetweenBulletsAux >= timerBetweenBullets){
			timerBetweenBulletsAux = 0;
			var bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
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

	void OnTriggerEnter2D(Collider2D other){
			if(other.gameObject.layer == Layers.Enemies){
				Health enemyhealth = other.GetComponent<Health>();
				Debug.Log("Health type: " + health.GetType());
				if(health)
					enemyhealth.CurrentHealth--;
				else
					Destroy(other.gameObject);
				health.CurrentHealth--;
			}
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
		// SceneManager.LoadScene("Death");
	}
}
