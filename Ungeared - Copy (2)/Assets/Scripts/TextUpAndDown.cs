using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUpAndDown : MonoBehaviour
{
[SerializeField] private Transform text;
private float moveAmount;
private float moveDuration;
private bool increasing;
private int tracker;
    // Start is called before the first frame update
    void Start()
    {
        moveAmount = (float).1;
        moveDuration = 100;
        increasing = true;
        tracker = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
         if(increasing == true){
       text.Translate(0,moveAmount,0);
        tracker +=1;
    }
    if(tracker >moveDuration){
        increasing =false;
    }
    if(increasing == false){
       text.Translate(0,0-moveAmount,0);
        tracker-=1;
    }
    if(tracker<1){
        increasing =true;
    }
    }
}
