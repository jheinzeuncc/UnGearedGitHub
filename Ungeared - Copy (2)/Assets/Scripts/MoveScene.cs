using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void MoveToScene(int sceneID){
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneID);
    }
}
