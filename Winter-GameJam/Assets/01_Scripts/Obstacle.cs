using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] AgentAnimation agentAnim;
    [SerializeField] GameObject AfterDead;
    [SerializeField] PlayerMovement move;

    private void Start()
    {
        move.enabled = true;
        AfterDead.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 21)
        {
            agentAnim.Dead();
            AfterDead.SetActive(true);
            move.enabled = false;
        }
    }
}
