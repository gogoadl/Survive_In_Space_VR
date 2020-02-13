using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public GameObject enemy;

    public GameObject targetPlayer;

    public GameObject enemyBullet;

    public float distance = 5;

    public float speed = 1.0f;

    public int bulletDamage = 10;

    Vector3 targetDistance;
    private void Start()
    {
        enemyBullet = this.gameObject;

        targetDistance = targetPlayer.transform.position - new Vector3(0,0.5f,0);
        transform.LookAt(targetDistance);
    }
    public void Update()
    { 
        transform.position += transform.forward * speed * Time.deltaTime;
        
        if(Vector3.Distance(enemy.transform.position, enemyBullet.transform.position) > 50)
        {
            if(enemyBullet)
            {
                Debug.Log("거리초과로 총알 삭제");
                Destroy(enemyBullet);
            }
                
        }
         

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
            GameManager.instance.playerHP -= 10;
            Debug.Log("플레이어와 적 총알 부딪힘");    
        }
    }

}
    
