using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmCode : MonoBehaviour
{
    private bool canCatch;
    RobotArm robotArm;

    private void Awake()
    {
        robotArm = transform.parent.parent.parent.parent.parent.GetComponent<RobotArm>();
    }
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){

            canCatch = true;   
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(robotArm.isPlayAnimEnd == true) canCatch = false;
            if (canCatch)
            {
                collision.transform.position = transform.position;
            }
        }
    }
}
