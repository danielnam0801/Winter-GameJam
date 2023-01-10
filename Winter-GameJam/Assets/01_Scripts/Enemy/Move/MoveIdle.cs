using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIdle : Move
{
    public float thinkTime = 4f;
    float t = 0;
    public void Think()
    {
        t+= Time.deltaTime;
        if(t > thinkTime)
        {
            currentVelocity = Random.Range(-2f,3f);
            if(currentVelocity == 0) while(currentVelocity != 0)
            {
                currentVelocity = Random.Range(-2f, 3f);    
            }
            t = 0;
            thinkTime = Random.Range(3.5f, 5f);
        }
    }
    public override void Moving(Vector2 firstPos, Vector2 secondPos)
    {
        Think();
        if (transform.position.x > secondPos.x)
        {
            currentVelocity = -1;
        }
        if (transform.position.x < firstPos.x)
        {
            currentVelocity = 1;
        }
    }
}
