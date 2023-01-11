using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class PlayerAttacked : MonoBehaviour
{

    [SerializeField] GameObject robotArm;

    public UnityEvent isNoWatingContactEvent; // 닿는 순간 바로 튈때 실행할이벤트
    public UnityEvent isWatingContactEvent; // 닿고 로봇팔이 던지는 적일때 실행할 것

    PlayerMovement playerMovement;

    Rigidbody2D rigidbody;
    BoxCollider2D collider;
    
    public float leftValue = 1f, upValue = 3f, backPower = 2f;

    public bool isContacting = false;
    public bool isAttacked = false;

    IEnumerator backPowerCoroutine;

    private Vector3 TransformPOS; 

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isAttacked)
        {
            //transform.position = TransformPOS;
        }
    }

    public void OnAttackedPlay(int layerName, float leftValue, float upValue, float backPower)
    {
        Debug.Log(layerName); // layer가 NoWaitingEnemy일때 12를 넘겨줘야함
        if (layerName == 12)
        {
            Debug.Log("NOWaiting");
            backPowerCoroutine = NoWaitingShooting(leftValue, upValue, backPower);
            if(backPowerCoroutine != null)
                StopCoroutine(backPowerCoroutine);
            StartCoroutine(backPowerCoroutine);
        }
    }

    public void OnWaitAttackedPlay(int layerName, float leftValue, float upValue, float backPower, Transform playerStopTransform)
    {
        if (layerName == 13) // layer가 WaitingEnemy일때 13을 넘겨줘야함
        {
            Debug.Log("Waiting");
            backPowerCoroutine = WaitingShooting(leftValue, upValue, backPower, playerStopTransform);
            if (backPowerCoroutine != null)
                StopCoroutine(backPowerCoroutine);
            StartCoroutine(backPowerCoroutine);
        }
    }
    IEnumerator NoWaitingShooting(float leftValue, float upValue, float backPower)
    {
        isNoWatingContactEvent.Invoke();
        playerMovement.isCatched = true;
        yield return new WaitForSeconds(0.05f);
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce((Vector2.left * leftValue + Vector2.up * upValue) * backPower, ForceMode2D.Impulse);

        yield return new WaitUntil(() => playerMovement.onGround);
        playerMovement.isCatched = false;
    }

    IEnumerator WaitingShooting(float leftValue, float upValue, float backPower, Transform playerStopTransform)
    {
        playerMovement.isCatched = true;
        isAttacked = true;
        yield return new WaitForSeconds(1f);// 플레이어 정지되고 기다릴 시간;
        GameObject robot = Instantiate(robotArm, new Vector2(playerStopTransform.position.x, playerStopTransform.position.y), Quaternion.identity);
        yield return new WaitUntil(()=>robot.GetComponentInChildren<RobotArm>().isPlayAnimEnd == true);
        isAttacked = false;
        isNoWatingContactEvent.Invoke();
        yield return new WaitForSeconds(0.05f);
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce((Vector2.left * leftValue + Vector2.up * upValue) * backPower, ForceMode2D.Impulse);

        yield return new WaitUntil(() => playerMovement.onGround);
        playerMovement.isCatched = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RobotArm"))
        {
            //TransformPOS = collision.transform.GetChild(2).transform.position;
            Debug.Log(collision.gameObject.name);
        }
    }
}
