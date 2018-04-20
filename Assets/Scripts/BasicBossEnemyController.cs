using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBossEnemyController : BasicEnemyController {
    public GameObject bulletPrefab;
    public float bulletSpeed;
    [Range(0.0f, 1.0f)]
    public float bulletThreshold;
    public AudioClip shot;
    private AudioSource audioSource;
    private GameObject playerPlane;
    void Awake(){
        playerPlane = GameObject.Find("Player");
    }

    protected override void Start () {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        if (!PauseMenu.GameIsPaused && Random.Range(0.0f, 1.0f) < bulletThreshold){
            spawnBullets();
        }
    }

    protected void spawnBullets(){
        var direction = playerPlane.transform.position - transform.position;
        float bulletRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, bulletRotation - 90));
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized  * bulletSpeed;
        audioSource.clip = shot;
        audioSource.Play();
    }

    protected override void DetermineDirection()
    {
    }
}