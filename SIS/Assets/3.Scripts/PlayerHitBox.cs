using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public GameObject bulletObject;
    GameManager gm;

    //플레이어가 총알을 맞음
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == bulletObject)
        {
            gm.SendMessage("PlayerHit");
            Destroy(collision.gameObject);
            Debug.Log("총알과 부딛혔습니다.");
        }     
    }


}
