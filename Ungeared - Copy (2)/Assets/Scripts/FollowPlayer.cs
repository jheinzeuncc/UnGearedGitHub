using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform trans; 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int health;
    [SerializeField] private GameObject gear;
    GameObject player; 
    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start(){
        if(health == 0){
        health = 100;}
       player = GameObject.Find("FirstPersonController"); //.transform.position;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        FaceTarget();
        //transform.LookAt(player);
        //Vector3 test = player.Transform.localPosition;
        //LookAt(GameManager.instance.MainCamera.transform);
    }

    public void FaceTarget(){
        //Vector3 towardsPlayer = playerPosition -trans.position;
        
        Vector3 towardsPlayer = (playerPosition-trans.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation (towardsPlayer);
        trans.rotation = Quaternion.Lerp(trans.rotation, targetRotation, rotationSpeed *Time.deltaTime);


    }

    public void Damage(int damage){
        health -= damage;
        if(health<=0){
             SpawnGear();
            Destroy(gameObject);
        }
    }

    private void SpawnGear(){
        GameObject spawnedGear = (GameObject)Instantiate(
           

            gear, trans.position, trans.rotation);
    }
}
