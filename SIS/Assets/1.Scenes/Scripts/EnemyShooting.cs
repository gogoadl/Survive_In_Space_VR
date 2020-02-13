using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;

    public GameObject player;

    public AudioClip enemyShootSound;
    GameObject enemyBullet;

    float shootingFrequency;
    float shootingStartFrequency;
    // Start is called before the first frame update
    void Start()
    {
        shootingStartFrequency = Random.Range(3f, 7f);
        shootingFrequency = Random.Range(2f, 4f);
        InvokeRepeating("Shooter", shootingStartFrequency, shootingFrequency);
    }
    private void Update()
    {
    }
    void Shooter()
    {   
        shootingFrequency = Random.Range(2f, 4f);
        shootingStartFrequency = Random.Range(5f, 7f);
        AudioSource.PlayClipAtPoint(enemyShootSound, transform.position);
        enemyBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        enemyBullet.GetComponent<BulletMovement>().targetPlayer = GameObject.FindWithTag("MainCamera");
        enemyBullet.GetComponent<BulletMovement>().enemy = this.gameObject;
    }
   
}
