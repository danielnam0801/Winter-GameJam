using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    //public UnityEvent
    [SerializeField] Transform firstPos;
    [SerializeField] Transform secondPos;

    EnemyTYpe enemyTypes;
    EnemyTypes enemyType;
    Rigidbody2D rb;

    public bool detectedPlayer = false;
    public bool isThink = true;
    public bool isWatingPlayerThrow = false;

    Move movement;

    float currentVelocity = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTypes = this.GetComponentInParent<EnemyTYpe>();
        this.enemyType = enemyTypes.thisEnemyType;
        MoveInit();
    }

    private void MoveInit()
    {
        if (enemyType == EnemyTypes.OnlyMovesUpperDownEnemy)
        {
            movement = GetComponent<MoveY>();
        }
        if(enemyType == EnemyTypes.OnlyMoveSideEnemy)
        {
            movement = GetComponent<MoveX>();
        }
    }

    private void Start()
    {
        firstPos = transform.parent.GetChild(0);
        secondPos = transform.parent.GetChild(1);
        this.transform.position = new Vector3(firstPos.position.x, firstPos.position.y, 0);
        Debug.Log(movement);
    }

    private void Update()
    {
        this.currentVelocity = movement.currentVelocity;
        #region OnlyMoveSideType
        if (enemyType == EnemyTypes.OnlyMoveSideEnemy)
        {
            OnlyMoveSideEMY();
        }
        #endregion
        #region OnlyMoveUpperDown
        if (enemyType == EnemyTypes.OnlyMovesUpperDownEnemy)
        {
            OnlyMoveUpperDownEmy();
        }
        #endregion
        #region humanType
        if (enemyType == EnemyTypes.humanTypeEnemy)
        {

        }
        #endregion
    }
    private void PlayerDetectedCheck()
    {
        if (detectedPlayer)
        {
            isThink = false;
            currentVelocity = 0;
        }
        else
        {
            if (currentVelocity == 0)
            {
                currentVelocity = Random.Range(-1, 2);
                isThink = true;
                Debug.Log("Waitin");
            }
            movement.Moving(firstPos.position, secondPos.position);
        }
    }

    private void OnlyMoveSideEMY()
    {
        PlayerDetectedCheck();
        rb.velocity = new Vector2(currentVelocity, 0) * movement.moveSO.maxSpeed;
    }


    private void OnlyMoveUpperDownEmy()
    {
        PlayerDetectedCheck();
        rb.velocity = new Vector2(0, currentVelocity) * movement.moveSO.maxSpeed;
    }

    IEnumerator WaitingPlayerThrow() //플레이어 던지고 나서 기다리는 시간
    {
        yield return new WaitForSeconds(0.5f);
        currentVelocity = Random.Range(-1, 2);
        isWatingPlayerThrow = true;
    }
}
