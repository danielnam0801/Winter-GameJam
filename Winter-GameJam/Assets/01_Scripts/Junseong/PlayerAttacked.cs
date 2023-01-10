using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAttacked : MonoBehaviour
{
    PlayerMovement playerMovement;

    Rigidbody2D rigidbody;

    public bool isAttackPlaying = true; // ó���� true������ ���� �̻��ϰ� �ڶ�¥���׷�
    [SerializeField]
    private float leftValue = 1f, upValue = 3f, backPower = 2f;

    public float countTime = 2f; // ������ �ִϸ��̼� ��� �ð����� �ٲ�����
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
            yield return new WaitForSeconds(0.3f);//��� �������� �ִϸ��̼� ���������� ���ߴ°ŷ� �ٲ���� // �������� �ִϸ��̼ǿ� ���缭 ���
            rigidbody.AddForce(((Vector2.left * leftValue) + (Vector2.up * upValue)) * backPower, ForceMode2D.Impulse);
            yield return new WaitUntil(() => playerMovement.onGround);
            isAttackPlaying = false;
            playerMovement.isAttacked = false;
            yield return null;
            t = 0; // Ȥ�� ���� 1������ �ڿ� �ʱ�ȭ
        }
    }
}
