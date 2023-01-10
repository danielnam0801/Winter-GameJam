using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class PlayerAttacked : MonoBehaviour
{

    public UnityEvent isContactEvent;

    PlayerMovement playerMovement;

    Rigidbody2D rigidbody;
    BoxCollider2D collider;

    [SerializeField]
    private float leftValue = 1f, upValue = 3f, backPower = 2f;

    public bool isContacting = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
      
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if(collision.collider.gameObject.layer == LayerMask.NameToLayer("NoDelayShootEnemy"))
    //    {

    //        if (collision.transform.GetComponentInParent<TriggerOnOff>().isPlayerCollision == false)
    //        {
    //            Debug.Log("isCOll");
    //            StopCoroutine("NoWaitingShooting");
    //            StartCoroutine("NoWaitingShooting");
    //        }
    //    }

    //    if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    //    {
    //        isContacting = true;
    //    }  
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    //    {
    //        isContacting = false;
    //    }
    //    if (collision.collider.gameObject.layer == LayerMask.NameToLayer("NoDelayShootEnemy"))
    //    {
    //        isContacting = false;
    //    }
    //}

    public void OnAttackedPlay(LayerMask layerName)
    {
        if (layerName == 12)
        {
            Debug.Log("NOWaiting");
            StopCoroutine("NoWaitingShooting");
            StartCoroutine("NoWaitingShooting");
        }
    }
    IEnumerator NoWaitingShooting()
    {
        isContactEvent.Invoke();
        rigidbody.velocity = Vector3.zero;
        playerMovement.isCatched = true;
        yield return new WaitForSeconds(0.05f);
        rigidbody.AddForce((Vector2.left * leftValue + Vector2.up * upValue) * backPower, ForceMode2D.Impulse);

        yield return new WaitUntil(() => playerMovement.onGround);
        playerMovement.isCatched = false;
    }
}
