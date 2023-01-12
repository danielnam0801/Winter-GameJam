using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectObstacle : MonoBehaviour
{
    public UnityEvent PlayerDieEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.gameObject.layer);

        if (collision.gameObject.layer == 8)
        {
            PlayerDieEvent?.Invoke();
            Debug.Log("Dieeeeeeeeeee");
        }
    }
}
