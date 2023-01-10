using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    MapManager mapManager;
    
    private void Awake()
    {
       mapManager = GameObject.Find("Manager").GetComponent<MapManager>();
    }
    private void Start()
    {
        
    }

}
