using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    PolygonCollider2D detectCollider;
    EnemyMovement _enemyMovement;
    PlayerMovement _playerMovement;

    public float CountTimeWitPlayerCatch = 0.3f; // 플레이어를 잡기 위한 최소 시간
    public float t = 0;

    private void Start()
    {
        detectCollider = GetComponent<PolygonCollider2D>();
        _enemyMovement = transform.GetComponentInParent<EnemyMovement>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            t = 0;
            _enemyMovement.detectedPlayer = true;
            //_playerMovement.isAttacked = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            t+= Time.deltaTime;
            if(t > CountTimeWitPlayerCatch)
            {
                _playerMovement.isAttacked = true;
            
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_playerMovement.isAttacked)
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
        _enemyMovement.detectedPlayer = false;
    }
}
