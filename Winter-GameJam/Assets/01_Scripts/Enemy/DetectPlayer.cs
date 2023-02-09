using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    PolygonCollider2D detectCollider;
    RotateEnemy _rotateEnemy;
    PlayerMovement _playerMovement;
    Collider2D enemyCollider;
    Transform target;
    PlayerAttacked playerAttacked;

    public float CountTimeWitPlayerCatch = 2f; // 플레이어를 잡기 위한 최소 시간
    //public float t = 0;
    //public float lightAngle = 0;
    //public float lightRadius = 0;

    public float leftValue = 6;
    public float upValue = 7;
    public float backPowerValue = 3;


    public bool isCanDetect = false;
    public bool isPlayerDetect;
    public bool isPlayerDetectCount = false;
    private bool canAttack = true;

    Coroutine playerCheckCoroutine;

    private void Awake()
    {
        playerAttacked = GameObject.Find("Player").GetComponentInChildren<PlayerAttacked>();
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        target = GameObject.Find("Player").transform;
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
        if (playerAttacked.isAttacked == false)
        {
            if (collision.gameObject.layer == 7 || collision.gameObject.layer == 9)
            {

            }
            else
            {
                if (collision.CompareTag("Player"))
                {
                    //Debug.Log("PlayerDeTECT성공");
                    PlayerCheck();
                    isCanDetect = true;
                    if (isPlayerDetect)
                    {
                        if (canAttack)
                        {
                            isPlayerDetectCount = true;
                            StartCoroutine("PlayerWaitingCheck");
                            canAttack = false;
                            Debug.Log(this.gameObject.layer);
                        }
                    }
                    else
                    {
                        StopCoroutine("PlayerWaitingCheck");
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCanDetect = false;
            canAttack = true;
        }
        if (isPlayerDetectCount) StopCoroutine("PlayerWaitingCheck");
    }

    private void PlayerCheck()
    {
        Vector3 dir = target.position - transform.position;
        RaycastHit2D playerCheckRay = Physics2D.Raycast(transform.position, dir, 15f, 1 << 6 | 1 << 9 | 1 << 7);
        Debug.DrawRay(transform.position, dir * 15f);
        if (playerCheckRay.collider == null)
        {
            isPlayerDetect = false;
        }
        else
        {
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

    IEnumerator PlayerWaitingCheck()
    {

        yield return new WaitForSeconds(CountTimeWitPlayerCatch);
        if (isPlayerDetect)
        {
            _playerMovement.isCatched = true;
            isPlayerDetectCount = false;
            playerAttacked.OnWaitAttackedPlay(13, leftValue, upValue, backPowerValue, target.transform);
        }
    }

}
