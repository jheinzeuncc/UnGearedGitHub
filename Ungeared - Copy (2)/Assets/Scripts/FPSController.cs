using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float runSpeed = 50.0f;
    [SerializeField] private float gravity = 5.0f;
     public int currentHealth;
     private int maxHealth ;
     public int gears;
     private int playerAttackDamage;
    

    [Header("Look Values")]
    [SerializeField, Range(1,10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1,10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1,10)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1,10)] private float lowerLookLimit = 80.0f;

    
    //controllers
    private Camera playerCamera;
    private CharacterController characterController;
   
    //Vectors
    private Vector3 moveDirection;
    private Vector2 currentInput;
    //Floats
    private float rotationX = 0;
    private float speed; 



    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        
        Cursor.visible = false;
        //set max health, current health 
        maxHealth = 100;
        currentHealth = maxHealth;
        gears = 0;
       playerAttackDamage = 25;
       GUIManager.instance.damage = playerAttackDamage;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //do nothing if paused
        if(PauseMenu.GameIsPaused == true){
            return;
        }
        movementInput();
        mouseLook();
        applyMovement();
        updateHealth();
        cheats();
       // quitToMenu();
        
    }

    private void quitToMenu(){
        if(Input.GetKey(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    private void movementInput(){
        //Set player running
        if(Input.GetKey(KeyCode.LeftShift)){
            speed=runSpeed;
        }
        else{
            speed=walkSpeed;
        }
       // print(speed);
        
        //Set the vector for the X based on direction
        currentInput = new Vector2(speed * Input.GetAxis("Vertical"), speed * Input.GetAxis("Horizontal"));
        //Store the y
        float moveDirectionY = moveDirection.y;
        //Set the 3D Vector
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x + (transform.TransformDirection(Vector3.right)*currentInput.y));
        moveDirection.y = moveDirectionY;
    }

    private void mouseLook(){
        //Get the rotation and look in that direction
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);

    }

    private void applyMovement(){
        //Gravity
        if(!characterController.isGrounded){
           moveDirection.y -= gravity *Time.deltaTime;    
        }
        //Move character
        characterController.Move(moveDirection * Time.deltaTime);


    }

    private void updateHealth(){
        if(currentHealth <=0){
            SceneManager.LoadScene(2);
            print("you died");
        }
      
        currentHealth = GameManager.instance.currentHealth;

        float healthPercentage = (float)currentHealth/(float)maxHealth;
        GUIManager.instance.UpdateHealthBar(healthPercentage);
        GUIManager.instance.UpdateHealth(currentHealth);

    }

    public void playerDamage(int damage){
        currentHealth -= damage;
        updateHealth();
    }

    public void OnTriggerEnter(Collider collision){
          
        if(collision.gameObject.tag == "Pickup"){
            print("pickup");
            gears = gears+1;
            print(gears);
            GUIManager.instance.setGears(gears);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag =="Victory"){
            SceneManager.LoadScene(3);
        }
    }

    public bool buyUpgrade(int cost){
        if(gears>= cost){
            gears = gears - cost;
            GUIManager.instance.setGears(gears);
            return true;
        }
        else{
            return false;
        }
    }
    public void increaseAttack(){
        playerAttackDamage = playerAttackDamage +5;
        GUIManager.instance.damage = playerAttackDamage;
        updateHealth();
    }
    public void increaseHealth(){
        maxHealth = maxHealth+25;
        GameManager.instance.currentHealth = GameManager.instance.currentHealth+25;
        print (maxHealth);
        updateHealth();
        
    }
    public void increaseAttackSpeed(){
        print("wip");
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Victory"){
            
        }
    }

    private void cheats(){
         if(Input.GetKey(KeyCode.RightAlt)){
            if(Input.GetKey(KeyCode.R)){
                
                gameObject.GetComponent<playerShooting>().increaseAttackSpeed();
                gameObject.GetComponent<playerShooting>().increaseAttackSpeed();
                gameObject.GetComponent<playerShooting>().increaseAttackSpeed();
            }
            if(Input.GetKey(KeyCode.K)){
               for (int i = 0; i < 100; i++) 
{
                    increaseAttack();
                }
               
            }
        }
    }

}
