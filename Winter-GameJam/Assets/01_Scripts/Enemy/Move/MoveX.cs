using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : Move
{

    public override void Moving(Vector2 firstPos, Vector2 secondPos)
    {
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
