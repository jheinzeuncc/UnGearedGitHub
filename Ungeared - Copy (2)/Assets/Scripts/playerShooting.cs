using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
   
   public float moveForce;
    public GameObject Bullet;
    public Transform gun;
    public float shootRate;
    public float shootForce;
    private float m_shootRateTimeStamp;
    Animator m_Animator;

    void Update()
    {
        //do nothing if paused
          if(PauseMenu.GameIsPaused == true){
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                GameObject go = (GameObject)Instantiate(
                Bullet, gun.position, gun.rotation);

                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                m_shootRateTimeStamp = Time.time + shootRate;
            }

        }

    }
    public void increaseAttackSpeed(){
        shootRate = shootRate -.1f;
    }
}
