using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField] private Transform trans; 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int bulletDamage;
    GameObject player; 
    Vector3 playerPosition;
    public bool active;
    public bool facingPlayer;
    Vector3 towardsPlayer;
    private float radiusOfSatisfaction;
    private Vector3 vec;
    


    #region start
    // Start is called before the first frame update
    void Start(){
    //find the player 
    player = GameObject.Find("FirstPersonController"); 
    towardsPlayer = (playerPosition-trans.position).normalized;
    //set the bullet to start off inactive
    active = true;
    //set how close bullet has to be
    radiusOfSatisfaction = 1f;
    //Align to the player
    FaceTarget();
    //Make sure bullet damage has a value
    if ( bulletDamage == null){
        bulletDamage = 1;
    }
    trans.Rotate(trans.transform.rotation.eulerAngles.x-90,trans.transform.rotation.eulerAngles.y,trans.transform.rotation.eulerAngles.z); 
    //Move bullet up to the barrel of the gun 
    vec = new Vector3(0f,.6f,0f);
    trans.Translate(vec, Space.World);  
   
    }
    #endregion

    
    // Update is called once per frame
    void Update()
    {
        
       if(active == true){
        MoveToTarget();
       }
    }

    #region public methods
    public void FaceTarget(){
       playerPosition = player.transform.position;
        //Get the vector to face the player
        Vector3 towardsPlayer = (playerPosition-trans.position).normalized;
        //Rotate to face the player
        //set speed
        //float step = moveSpeed * Time.deltaTime;
        //get direction 
       Vector3 newDir = Vector3.RotateTowards(transform.forward, towardsPlayer, 180f, 0.0f);
       //Face the player 
       transform.rotation = Quaternion.LookRotation(newDir);
       //Rotate so the bullet is oriented correctly
       trans.transform.Rotate(90f,90f,90f,Space.Self);
    }
    public void activateBullet(){
        active = false;
    }
    #endregion


    private void MoveToTarget(){
        if(facingPlayer == false){
            towardsPlayer = (playerPosition-trans.position).normalized;
            FaceTarget();
            facingPlayer = true;
        }
        //How much to move
        Vector3 movementAmount = towardsPlayer * moveSpeed * Time.deltaTime;

        //Move
        trans.position += movementAmount;
        //If hitting the player do damage and get rid of bullet
        if(Vector3.Distance (trans.position, player.transform.position)< radiusOfSatisfaction){
            trans.position = new Vector3(0,-50,0);
            
            GameManager.instance.currentHealth -=bulletDamage;
            active = false;
            facingPlayer = false;
        }
    }
    //reset the bullet values
    public void resetBullet(){
        FaceTarget();
        active = true;
        facingPlayer = false;
    }


    private void OnCollisionEnter(Collision other){
       if(other.gameObject.tag == "DestroysLasers"){
            Destroy(gameObject);}
        
    }

}
