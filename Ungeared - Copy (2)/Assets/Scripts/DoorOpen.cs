using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
[SerializeField] private List<Transform> Doors;
[SerializeField] private List<GameObject> keyList;
private Vector3 vec;
private float startPos;


    // Start is called before the first frame update
    void Start()
    {
        vec = new Vector3(0,3.85f,0);
        startPos = Doors[0].position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
    }
    
    public void openDoor(){
        for(int i =0; i<keyList.Count;i++){
          
            if(keyList[i]!= null){
                return;
            }
        }
       moveDoorsUp();
    }

    private void moveDoorsUp(){
         
        print("doors going up");
        for(int i = 0;i<Doors.Count;i++ ){

            vec = new Vector3(Doors[i].position.x,Doors[i].position.y + 3.85f, Doors[i].position.z);

            Doors[i].position = Vector3.MoveTowards(Doors[i].position,vec,2f*Time.deltaTime);
            if(Doors[i].position.y >startPos+6f){
                Destroy(Doors[i].gameObject);
            }
        }
    }
}
