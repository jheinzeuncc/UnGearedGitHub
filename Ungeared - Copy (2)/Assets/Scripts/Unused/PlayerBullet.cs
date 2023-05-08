using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{   
     [SerializeField] private Transform trans;
     [SerializeField] private GameObject player;
     private Quaternion direction;
     private bool active;
     private Vector3 moveDirection;

     
    // Start is called before the first frame update
    void Start()
    {
        
        direction = player.transform.localRotation;
        active = true;
        fire();
    }

    // Update is called once per frame
    void Update()
    {
        if(active== true){
            move();
        }
    }

    private void move(){
        moveDirection = (transform.TransformDirection(Vector3.forward));
       
        
    }
    private void fire(){
        //Set the location to be of the players location
        Vector3 fireLocation;
        fireLocation = player.transform.position;
        //fireLocation += new Vector3 (0f,0f,1f);
        trans.transform.position = fireLocation;
        
        //Rotate to face the direction of the player 
        direction = player.transform.localRotation;
        trans.transform.rotation = (player.transform.localRotation);
        trans.transform.Rotate(90f,90f,90f,Space.Self);

        Invoke("fire",2);
    }
}
