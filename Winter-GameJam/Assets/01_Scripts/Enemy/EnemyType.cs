using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes
{
    AngleTransEnemy,
    OnlyMoveSideEnemy,
    OnlyMovesUpperDownEnemy,
    humanTypeEnemy
}

public class EnemyType : MonoBehaviour
{
    public EnemyTypes thisEnemyType;
}
