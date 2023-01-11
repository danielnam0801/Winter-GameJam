using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RotateDetectEnemy : MonoBehaviour
{
    PolygonCollider2D detectCollider;
    RotateEnemy _rotateEnemy;
    PlayerMovement _playerMovement;
    Light2D light2D;
    Collider2D enemyCollider;
    Transform target;
    PlayerAttacked playerAttacked;

    public float CountTimeWitPlayerCatch = 0.3f; // 플레이어를 잡기 위한 최소 시간
    //public float t = 0;
    //public float lightAngle = 0;
    //public float lightRadius = 0;

    public float leftValue = 6;
    public float upValue = 7;
    public float backPowerValue = 3;


    public bool isCanDetect=false;
    public bool isPlayerDetect;
    private bool canAttack = true;

    private void Awake()
    {
        playerAttacked = GameObject.Find("Player").GetComponentInChildren<PlayerAttacked>();
        target = GameObject.Find("Player").transform;
        _rotateEnemy = transform.GetComponent<RotateEnemy>();
        if(transform.parent == null)
        {
            light2D = transform.GetComponentInChildren<Light2D>();
        }
        else
        {
            light2D = transform.parent.GetComponentInChildren<Light2D>();
        }
        enemyCollider = GetComponent<Collider2D>();
    }
    private void Start()
    {
        //lightAngle = light2D.pointLightOuterAngle;
        //lightRadius = light2D.pointLightOuterRadius;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCanDetect = true;
            canAttack = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCheck();
            isCanDetect = true;
            if (isPlayerDetect)
            {
                if (canAttack)
                {
                    playerAttacked.OnAttackedPlay(13, leftValue, upValue, backPowerValue);
                    canAttack = false;
                    Debug.Log(this.gameObject.layer);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCanDetect=false;
            canAttack=true;
        }   
    }

    private void PlayerCheck()
    {
        Vector3 dir = target.position - transform.position;
        RaycastHit2D playerCheckRay = Physics2D.Raycast(transform.position, dir, 15f, 1 << 6);
        Debug.DrawRay(transform.position, dir * 15f);
        if(playerCheckRay.collider == null)
        {
            isPlayerDetect = false;
        }
        else
        {
            Debug.Log(playerCheckRay.collider.name);
            if (playerCheckRay.collider.CompareTag("Player"))
            {
                isPlayerDetect = true;
            }
            else
            {
                isPlayerDetect = false;
            }
        }
    }

}