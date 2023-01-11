using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(float x)
    {
        if(x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if(x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
