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
            transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
        }
        if(x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
    }
}
