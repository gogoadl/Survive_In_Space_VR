using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public int isLightOn;
    private int isBallIn;
    public GameObject ring;
    public GameObject beaconBase;
    public Material[] base_color; 
    // Start is called before the first frame update
    void Start()
    {
        isLightOn = 0;
        isBallIn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "PuzzleBall") {
            if (other.gameObject.tag == ring.gameObject.tag) {
                // PuzzleBall 과 색이 매칭될 시 효과음 발생 
                // Base 색 변경.
                beaconBase.GetComponent<MeshRenderer>().material = base_color[1];
                isLightOn = 1;
            }
            else {
                // PuzzleBall 과 색이 매칭되지 않을 시 효과음 발생 
                beaconBase.GetComponent<MeshRenderer>().material = base_color[0];
            }

            isBallIn = 1;
        }        
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "PuzzleBall") {
             if (other.gameObject.tag == ring.gameObject.tag)
            {
                // PuzzleBall 의 속성을 변경하여 해당 위치에 완전히 고정시킴.                
                pullBall(other.gameObject);                
            }
            else {
                // PuzzleBall 에게 상단 그리고 측면을 향한 힘을 가해 밀쳐냄.
                pushBall(other.gameObject);
            }
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "PuzzleBall") {
            isBallIn = 0;
        }
    }

    private float distance; 
    private void pullBall(GameObject ball) {
        distance = Vector3.Distance(ball.transform.position, transform.position);
        Vector3 dir = transform.position - ball.transform.position;
        dir.Normalize();
        ball.GetComponent<Rigidbody>().isKinematic = true;
        if (distance > 0.1f) {
            ball.transform.Translate(dir * 0.1f);
        }
        else {
            ball.transform.position = transform.position;
        }
    }

    private void pushBall(GameObject ball) {
        Vector3 dir = ball.transform.position - transform.position;
        dir.Normalize();

        ball.GetComponent<Rigidbody>().velocity = dir * 5.0f;
    }
}
