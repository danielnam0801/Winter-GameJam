using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAttacked : MonoBehaviour
{
    PlayerMovement playerMovement;

    Rigidbody2D rigidbody;

    public bool isAttackPlaying = true; // 처음에 true여야함 내가 이상하게 코뜨짜서그려
    [SerializeField]
    private float leftValue = 1f, upValue = 3f, backPower = 2f;

    public float countTime = 2f; // 던지는 애니메이션 재생 시간으로 바꿔주자
    public float t = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();    
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerMovement.isAttacked == true && t == 0)
        {
            while (t < countTime)
            {
                t += Time.deltaTime;
                if (t > countTime)
                {
                    isAttackPlaying = false;
                }   
            }
            if (playerMovement.isAttacked && !isAttackPlaying)
            {
                isAttackPlaying = true;
                StartCoroutine(AttackedWait());
            }
        }

        IEnumerator AttackedWait()
        {
            yield return new WaitForSeconds(0.3f);//잡고 던져지는 애니메이션 끝날때까지 멈추는거로 바꿔야함 // 던져지는 애니메이션에 맞춰서 재생
            rigidbody.AddForce(((Vector2.left * leftValue) + (Vector2.up * upValue)) * backPower, ForceMode2D.Impulse);
            yield return new WaitUntil(() => playerMovement.onGround);
            isAttackPlaying = false;
            playerMovement.isAttacked = false;
            yield return null;
            t = 0; // 혹시 몰라서 1프레임 뒤에 초기화
        }
    }
}
