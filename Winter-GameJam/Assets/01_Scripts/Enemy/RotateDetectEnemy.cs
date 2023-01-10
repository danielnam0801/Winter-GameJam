using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDetectEnemy : MonoBehaviour
{
    PolygonCollider2D detectCollider;
    RotateEnemy _rotateEnemy;
    PlayerMovement _playerMovement;

    public float CountTimeWitPlayerCatch = 0.3f; // 플레이어를 잡기 위한 최소 시간
    public float t = 0;

    private void Start()
    {
        detectCollider = GetComponent<PolygonCollider2D>();
        _rotateEnemy = transform.GetComponentInParent<RotateEnemy>();
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            t = 0;
            _rotateEnemy.playerdetected = true;
            //_playerMovement.isAttacked = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            t += Time.deltaTime;
            if (t > CountTimeWitPlayerCatch)
            {
                _playerMovement.isCatched = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_playerMovement.isCatched)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                StartCoroutine(MoveBooleanOn());
            }
        }
        t = 0;
    }
    IEnumerator MoveBooleanOn()
    {
        yield return new WaitForSeconds(1f);
        _rotateEnemy.playerdetected = false;
    }
}