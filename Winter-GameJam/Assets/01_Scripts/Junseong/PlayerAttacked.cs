using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacked : MonoBehaviour
{
    PlayerMovement playerMovement;

    Rigidbody2D rigidbody;

    public bool isAttackPlaying;
    [SerializeField]
    private float leftValue = 1f, upValue = 3f, backPower = 2f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerMovement.isAttacked && !isAttackPlaying)
        {
            isAttackPlaying = true;
            StartCoroutine("AttackedWait");
        }
    }

    IEnumerator AttackedWait()
    {
        yield return new WaitForSeconds(0.3f);//잡고 던져지는 애니메이션 끝날때까지 멈추는거로 바꿔야함 // 던져지는 애니메이션에 맞춰서 재생
        rigidbody.AddForce(((Vector2.left * leftValue) + (Vector2.up * upValue)) * backPower, ForceMode2D.Impulse);
        yield return new WaitUntil(()=>playerMovement.onGround);
        isAttackPlaying = false;
        playerMovement.isAttacked = false;
    }
    
}
