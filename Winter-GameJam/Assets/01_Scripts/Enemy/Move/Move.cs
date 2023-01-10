using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    public MovementSO moveSO;
    public float currentVelocity = 1;
    public abstract void Moving(Vector2 firstPos, Vector2 secondPos);

    private void Awake()
    {
        currentVelocity = 1;
    }
}
