using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnOff : MonoBehaviour
{
    PolygonCollider2D collider;
    PlayerAttacked playerAttacked;

    public bool isPlayerCollision = false;
    private void Awake()
    {
        collider = GetComponent<PolygonCollider2D>();
        playerAttacked = GameObject.Find("Player").GetComponent<PlayerAttacked>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(!isPlayerCollision)
         playerAttacked.OnAttackedPlay(this.gameObject.layer);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            isPlayerCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        isPlayerCollision = false;
    }
}
