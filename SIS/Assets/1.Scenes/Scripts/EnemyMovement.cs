using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject targetPlayer;

    public EnemyShooting enemyShooting;

    public GameObject explosionParticle;

    public AudioClip droneSound;

    public AudioClip explosionSound;

    public int shootingDistance = 35;
    public float distance = 20;

    public float speed = 1.0f;
    private void Start()
    {
        //AudioSource.PlayClipAtPoint();
    }

    public void Update()
    {
        transform.LookAt(targetPlayer.transform);

        if(Vector3.Distance(targetPlayer.transform.position, transform.position) < shootingDistance)
        {   
            enemyShooting.enabled = true;
        }

        if(Vector3.Distance(targetPlayer.transform.position,transform.position) > distance) // targetPlayer 와 Enemy 의 거리가 5 이상일 때
        {
            Vector3 dir = targetPlayer.transform.position - transform.position; // 타겟의 거리 - 나의 거리

            dir.Normalize();

            transform.position += (dir) * speed * Time.deltaTime; // 나의 위치는 dir X speed X 동기화
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.collider.tag == "playerBullet")
        {

            Destroy(this.gameObject);

            AudioSource.PlayClipAtPoint(explosionSound, transform.position,1.0f);

            GameObject.Instantiate(explosionParticle, transform.position, Quaternion.identity);

            GameManager.instance.score += 100;



            Debug.Log("플레이어 총알과 부딪히고 삭제");

        }
        
        
    }
}
