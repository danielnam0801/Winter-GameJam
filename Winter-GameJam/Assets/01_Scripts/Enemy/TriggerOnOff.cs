using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnOff : MonoBehaviour
{
    //PolygonCollider2D collider;
    PlayerAttacked playerAttacked;
    int playerDetectCount = 0;

    public float leftValue = 1f, upValue = 3f, backPower = 2f;

    public bool isPlayerCollision = false;
    private void Awake()
    {
        //collider = GetComponent<PolygonCollider2D>();
        playerAttacked = GameObject.Find("Player").GetComponent<PlayerAttacked>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAttacked>().leftValue = this.leftValue;
            collision.GetComponent<PlayerAttacked>().upValue = this.upValue;
            collision.GetComponent<PlayerAttacked>().backPower = this.backPower;
            if (!isPlayerCollision)
            {
                isPlayerCollision = true;
                playerDetectCount++;
                if (playerDetectCount == 1)
                {
                    isPlayerCollision = true;
                    playerAttacked.OnAttackedPlay(12,leftValue,upValue,backPower);
                    Debug.Log($"트리거 온 된 오브젝트 : {this.transform.parent.name}");
                }
            }
        }
    }
        

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    playerDetectCount++;
    //    if (playerDetectCount == 1)
    //    {
    //        isPlayerCollision = true;
    //        playerAttacked.OnAttackedPlay(this.gameObject.layer);
    //        Debug.Log($"트리거 온 된 오브젝트 : {this.transform.parent.name}");
    //    }
    //    if (other.CompareTag("Player"))
    //        isPlayerCollision = true;
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerCollision = false;
            playerDetectCount = 0;
        }
    }
}
