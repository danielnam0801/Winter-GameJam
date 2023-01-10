using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveY : Move
{

    public override void Moving(Vector2 firstPos, Vector2 secondPos)
    {
        if (transform.position.y > secondPos.y)
        {
            currentVelocity = -1;
        }
        if (transform.position.y < firstPos.y)
        {
            currentVelocity = 1;
        }
    }
}
