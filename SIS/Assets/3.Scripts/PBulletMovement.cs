using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBulletMovement : MonoBehaviour
{
   
    public GameObject Player;

    public Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        PlayerTransform = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerTransform.position, gameObject.transform.position) > 100)
            Destroy(gameObject);
     
        transform.position += transform.forward * Time.deltaTime * 50f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("부딪히고있다 레이져");
        }
        if(collision.collider.tag == "btnGameStart")
        {
            Debug.Log("게임시작");
        }
    }
}
