using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    PolygonCollider2D detectCollider;
    EnemyMovement _enemyMovement;
    PlayerMovement _playerMovement;

    public float CountTimeWitPlayerCatch = 0.3f; // �÷��̾ ��� ���� �ּ� �ð�

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
            _enemyMovement.detectedPlayer = true;
            _playerMovement.isAttacked = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            float t = 0;
            while () ;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _enemyMovement.detectedPlayer = false;
        }
    }
    
}
