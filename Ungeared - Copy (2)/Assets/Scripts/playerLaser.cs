using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaser : MonoBehaviour
{
    Transform trans;
    FollowPlayer followPlayer;
    private GameObject Fps;
    
    private int damage;
   
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
        Fps = GameObject.FindWithTag("fps");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.tag == "TakesDamage"){
            
            damage  =GUIManager.instance.damage;
            print(damage);

            followPlayer = collision.gameObject.GetComponent<FollowPlayer>();
            followPlayer.Damage(damage);
            Destroy(gameObject);
        }else{

            Destroy(gameObject);
        }
    }
    
}
