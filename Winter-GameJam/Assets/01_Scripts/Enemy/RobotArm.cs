using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm : MonoBehaviour
{
    public bool isPlayAnim = false;
    public bool isPlayAnimEnd = false;

    public void PlayAnimEnd()
    {
        isPlayAnimEnd = true;
    }

    public void Dead()
    {
        Destroy(transform.parent.gameObject);
    }
   
}
