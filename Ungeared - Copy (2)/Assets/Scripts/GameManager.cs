using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public FPSController player;
    public BulletMovement bullet;
    public Shoot turret;
    public int currentHealth;
   
    private void Awake()
    {
        if(instance == null){
            print("created");
            //create singleton
            instance = this;
            DontDestroyOnLoad (gameObject);
    }
    //If the singleton already exists, destroy this instance
    else{
        Destroy (gameObject);

    }
    }

    void Start(){
        //Set player current health
         currentHealth = 100;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
