using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int distanceTraveled = 0;

    [SerializeField] Transform target;
    public Transform Target => target;

    float targetsFirstPos;
    
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        if(instance == null)
        {
            instance = this;
        }
        //else DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        targetsFirstPos = target.transform.position.x;  
    }

    private void Update()
    {
        PlayerDistance();    
    }

    void PlayerDistance()
    {
        distanceTraveled = (int)(target.transform.position.x - targetsFirstPos);
    }
    
}
