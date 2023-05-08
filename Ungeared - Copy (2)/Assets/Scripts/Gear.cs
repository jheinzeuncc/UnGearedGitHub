using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private Transform gear;
    private int tracker;
    private bool increasing;
    // Start is called before the first frame update
    void Start()
    {
        tracker = 0;
        increasing = true;
        gear.Translate(0,-2,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //do nothing if paused
        if(PauseMenu.GameIsPaused == true){
            return;
        }
    
    if(increasing == true){
       gear.Translate(0,(float).01,0);
        tracker +=1;
    }
    if(tracker >100){
        increasing =false;
    }
    if(increasing == false){
       gear.Translate(0,(float)-.01,0);
        tracker-=1;
    }
    if(tracker<1){
        increasing =true;
    }
        
        
    }
}
