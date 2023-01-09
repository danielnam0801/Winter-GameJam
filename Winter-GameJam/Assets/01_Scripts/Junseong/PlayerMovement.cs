using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public UnityEvent OnMove;
    public UnityEvent OnStop;
    
    public MovementSO _movementSO;

    [Header("Bool")]
    public bool onGround;
    public bool onAir;
    public bool isMoving = false;
    public bool isAttacked;

    [Header("Player수치")]
    public float jumpPower = 10f;
    public float _currentVelocity = 0f;
    
    [Header("RayCast수치")]
    public float underRayCastDistanceValue = 0.1f;

    private Vector2 currentMoveDirection;
    

    [SerializeField] Transform pos;
    [SerializeField] float Radius;

    AgentRenderer agentRenderer;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        agentRenderer = transform.Find("VisualSprite").GetComponent<AgentRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacked)
        {
            Move();
            Jump();
        }
        GroundCheck();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if (x != 0)
        {
            isMoving = true;
            agentRenderer.FaceDirection(x);
            _currentVelocity = AccelSpeed(x);
        }

        else
        {
            DeAccelSpeed();
            OnStop?.Invoke();
        }
        rb.velocity = new Vector2(_currentVelocity, rb.velocity.y);
    }

    private void DeAccelSpeed()
    {
        if (isMoving)
        {
            if (_currentVelocity > 0)
            {
                _currentVelocity -= _movementSO.deAccel * Time.deltaTime;
                if(_currentVelocity <= 0)
                {
                    isMoving=false;
                    _currentVelocity = 0;
                } 
            }
            else
            {
                _currentVelocity += _movementSO.deAccel * Time.deltaTime;
                if (_currentVelocity >= 0)
                {
                    isMoving = false;
                    _currentVelocity = 0;
                }
            }
        }
        else _currentVelocity = 0;
    }

    private float AccelSpeed(float moveXPos)
    {
        if (moveXPos > 0)
        {
            _currentVelocity += _movementSO.Accel * Time.deltaTime;
            if(_currentVelocity > _movementSO.maxSpeed)
            {
                _currentVelocity = _movementSO.maxSpeed;
            }

        }
        else
        {
            _currentVelocity -= _movementSO.Accel * Time.deltaTime;
            if (_currentVelocity < -_movementSO.maxSpeed)
            {
                _currentVelocity = -_movementSO.maxSpeed;
            }
        }
        return _currentVelocity;
    }

    private void GroundCheck()
    {
        onGround = Physics2D.OverlapCircle(pos.position, Radius, Define.Ground);
        onAir = !onGround;
    }

    private void Jump()
    {
        if(onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

}
