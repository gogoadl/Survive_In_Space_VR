using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Collision : MonoBehaviour
{

    public SphereCollider playerHitbox;
    private GameManager gm;

    private void Start()
    {
        playerHitbox = GameObject.Find("HeadCollider").GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collision collision)
    {

        if(collision.collider == playerHitbox)
        {
            Destroy(this.gameObject);
            GameObject.Find("GameManager").SendMessage("PlayerHit");
            Debug.Log("플레이어 히트!");
        }
       else
            Destroy(this.gameObject);
    }
}
