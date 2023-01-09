using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public MovementSO _movementSO;
    Rigidbody2D rb;

    [SerializeField] Transform firstPos;
    [SerializeField] Transform secondPos;

    private float currentVelocity = 1;
    public Vector2 currentDir;

    public bool detectedPlayer = false;
    public bool isThink = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = new Vector3(firstPos.position.x,firstPos.position.y, 0);
        currentVelocity = 1;
    }

    private void Update()
    {
        if (!detectedPlayer)
        {
            if(currentVelocity == 0)
            {
                isThink = true;
                currentVelocity = Random.Range(-1, 2);
            }
            Move(this.firstPos.position, this.secondPos.position);
        }
        else
        {
            isThink=false;
            currentVelocity = 0;
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
}
