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
    public bool isCatched;
    public bool isCanHide;
    public bool isHiding;
    public bool isHidingPlaying = false;
    public bool isWall;

    [Header("Player수치")]
    public float jumpPower = 10f;
    public float _currentVelocity = 0f;
    
    [Header("RayCast수치")]
    public float underRayCastDistanceValue = 0.1f;

    private Vector2 currentMoveDirection;
    

    [SerializeField] Transform pos;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    [SerializeField] float Radius;

    AgentRenderer agentRenderer;
    PlayerAttacked playerAttacked;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    AgentAnimation playerAnim;
    private bool canMove = true;

    void Awake()
    {
        canMove = true;
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();    
        agentRenderer = transform.Find("VisualSprite").GetComponent<AgentRenderer>();
        playerAttacked = GetComponent<PlayerAttacked>();
        playerAnim = transform.Find("VisualSprite").GetComponent<AgentAnimation>();
    }

    void Start()
    {
        leftPos.position = boxCollider.bounds.center - new Vector3(boxCollider.bounds.size.x / 2, 0, 0);
        rightPos.position = boxCollider.bounds.center + new Vector3(boxCollider.bounds.size.x / 2, 0, 0);
        pos.position = boxCollider.bounds.center - new Vector3(0,boxCollider.bounds.size.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCatched)
        {
            if (isWall && onAir)
            {
                Move();
            }
            else
            {
                Move();
                Jump();
            }
            Hiding();
        }
        else _currentVelocity = 0;
        GroundCheck();
        HidingCheck();
        
        if(_currentVelocity != 0) playerAnim.Moving(true);
        else playerAnim.Moving(false);
        playerAnim.Hiding(isHiding);
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

        if (isCanHide && !onGround)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(_currentVelocity * -0.05f, 0f), ForceMode2D.Impulse);
        }
        if (isHidingPlaying) isHidingPlaying = false;
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
        onGround = Physics2D.Raycast(pos.position, Vector2.down, 0.1f, Define.Ground);
        onAir = !onGround;
        if (onAir == false) onGround = true;

        //if(onGround == true && !playerAttacked.isContacting)
        //{
        //    isCatched = false;
        //}

        playerAnim.IsGround(onGround);
    }
    private void HidingCheck()
    {
        RaycastHit2D leftCheck = Physics2D.Raycast(leftPos.position, Vector2.left, 0.1f, Define.Ground);
        RaycastHit2D rightCheck = Physics2D.Raycast(rightPos.position, Vector2.right, 0.1f, Define.Ground);
        
        isWall = leftCheck | rightCheck;
        isCanHide = onGround && (leftCheck | rightCheck);
    }

    private void Jump()
    {
        if(onGround && Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.IsJumping();
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void Hiding()
    {
        if(isCanHide && onGround && isHidingPlaying == false)
        {
            isHidingPlaying = true;
            isHiding = true;
            playerAnim.DoHide();
        }
        else
        {
            isHiding=false;
        }
    }

}
