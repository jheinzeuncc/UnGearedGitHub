using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGun : MonoBehaviour

{
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = (GameObject)Instantiate(
                gun, spawnLocation.position, spawnLocation.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
