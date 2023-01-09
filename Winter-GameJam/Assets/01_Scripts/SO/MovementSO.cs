using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/MOVEMENT")]
public class MovementSO : ScriptableObject
{
    [Range(0.1f, 10f)]
    public float maxSpeed = 10f;

    [Range(0.1f, 100f)]
    public float deAccel = 5f, Accel = 5f;

}
