using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerLeftShoot : MonoBehaviour
{

    public SteamVR_Action_Boolean ShootBullet;

    public SteamVR_Input_Sources HandType;

    public GameObject PlayerBullet;

    public Transform BulletRotation;

    private GameObject bullet;

    public AudioClip shootSound;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(ShootBullet.stateDown == true && gameObject.tag == "LeftHand")
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position,0.3f);
            bullet = Instantiate(PlayerBullet, BulletRotation.position, BulletRotation.rotation);
          
            Debug.Log("왼쪽 손에서 발사");
        }
      
        //bulletRigid.velocity = BulletRotation.forward * 5;

        //Debug.Log(Vector3.Distance(BulletRotation.position, bullet.transform.position));
        
    }
    
}
    