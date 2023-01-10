using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class PlayerAttacked : MonoBehaviour
{

    public UnityEvent isNoWatingContactEvent; // 닿는 순간 바로 튈때 실행할이벤트
    public UnityEvent isWatingContactEvent; // 닿고 로봇팔이 던지는 적일때 실행할 것

    PlayerMovement playerMovement;

    Rigidbody2D rigidbody;
    BoxCollider2D collider;
    
    public float leftValue = 1f, upValue = 3f, backPower = 2f;

    public bool isContacting = false;

    IEnumerator backPowerCoroutine;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
      
    }

    public void OnAttackedPlay(LayerMask layerName, float leftValue, float upValue, float backPower)
    {
        if (layerName == 12)
        {
            Debug.Log("NOWaiting");
            backPowerCoroutine = NoWaitingShooting(leftValue, upValue, backPower);
            if(backPowerCoroutine != null)
                StopCoroutine(backPowerCoroutine);
            StartCoroutine(backPowerCoroutine);
        }
        if(layerName == 13)
        {
            Debug.Log("Waiting");
            backPowerCoroutine = WaitingShooting(leftValue, upValue, backPower);
            if (backPowerCoroutine != null)
                StopCoroutine(backPowerCoroutine);
            StartCoroutine(backPowerCoroutine);
        }
    }
    IEnumerator NoWaitingShooting(float leftValue, float upValue, float backPower)
    {
        isNoWatingContactEvent.Invoke();
        rigidbody.velocity = Vector3.zero;
        playerMovement.isCatched = true;
        yield return new WaitForSeconds(0.05f);
        rigidbody.AddForce((Vector2.left * leftValue + Vector2.up * upValue) * backPower, ForceMode2D.Impulse);

        yield return new WaitUntil(() => playerMovement.onGround);
        playerMovement.isCatched = false;
    }

    IEnumerator WaitingShooting(float leftValue, float upValue, float backPower)
    {
        yield return null;
        //isNoWatingContactEvent.Invoke();
        //rigidbody.velocity = Vector3.zero;
        //playerMovement.isCatched = true;
        //yield return new WaitForSeconds(0.05f);
        //rigidbody.AddForce((Vector2.left * leftValue + Vector2.up * upValue) * backPower, ForceMode2D.Impulse);

        //yield return new WaitUntil(() => playerMovement.onGround);
        //playerMovement.isCatched = false;
    }
}
