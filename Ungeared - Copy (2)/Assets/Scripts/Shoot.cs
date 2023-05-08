using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour

{

    [SerializeField] private Transform bulletTrans;
    [SerializeField] private Transform gunTrans;
    [SerializeField] private GameObject bullet;
    BulletMovement bulletMovement;

    void Awake(){

        //bulletMovement = GameObject.Find("Bullet").GetComponent<BulletMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("shoot",5);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shoot(){
        Invoke("shoot",2);
       
        Vector3 fireLocation;
         /*fireLocation = gunTrans.transform.position;
        fireLocation += new Vector3 (0f,.65f,0f);
        bulletTrans.transform.position = fireLocation;*/
        GameObject fired = (GameObject)Instantiate(
            bullet, gunTrans.position, gunTrans.rotation);
    
        
       
        
    }

}
