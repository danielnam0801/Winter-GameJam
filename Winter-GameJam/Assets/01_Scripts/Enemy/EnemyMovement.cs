using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    //public UnityEvent
    public MovementSO _movementSO;
    Rigidbody2D rb;

    [SerializeField] Transform firstPos;
    [SerializeField] Transform secondPos;

    private float currentVelocity = 1;
    public Vector2 currentDir;

    public bool detectedPlayer = false;
    public bool isThink = true;
    public bool isWatingPlayerThrow = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = new Vector3(firstPos.position.x,firstPos.position.y, 0);
        currentVelocity = 1;
    }

    private void Update()
    {
        if (detectedPlayer)
        {
            isThink=false;
            currentVelocity = 0;
        }
        else
        {
            if(isWatingPlayerThrow)
            {
                isThink = true;
                isWatingPlayerThrow=false;
                StartCoroutine("WaitingPlayerThrow");
                Debug.Log("Waitin");
            }
            Move(this.firstPos.position, this.secondPos.position);
        }

        rb.velocity = new Vector2(currentVelocity, rb.velocity.y) * _movementSO.maxSpeed;
    }
    public void Move(Vector2 firstPos, Vector2 secondPos)
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

    IEnumerator WaitingPlayerThrow() //플레이어 던지고 나서 기다리는 시간
    {
        yield return new WaitForSeconds(0.5f);
        currentVelocity = Random.Range(-1, 2);
        isWatingPlayerThrow = true;
    }
}
