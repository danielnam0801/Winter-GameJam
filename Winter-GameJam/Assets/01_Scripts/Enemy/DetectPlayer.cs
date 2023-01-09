using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    PolygonCollider2D detectCollider;
    EnemyMovement _enemyMovement;
    private void Start()
    {
        detectCollider = GetComponent<PolygonCollider2D>();
        _enemyMovement = transform.GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _enemyMovement.detectedPlayer = true;
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
