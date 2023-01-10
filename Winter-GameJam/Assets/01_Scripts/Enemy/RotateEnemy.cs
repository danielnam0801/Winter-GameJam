using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class RotateEnemy : MonoBehaviour
{
    public bool isCanTwinkle = false; // Áß°£¿¡ ºûÀÌ ²¨Áö´Â ¾Ö´Â ¾ê¸¦ Æ®·ç·Î ÇØÁà¾ßÇÔ
    public bool isStop = false;

    private bool isThinking = false;

    float t = 0;
    public float thinkTime = 7f;

    public float stopTime = 3f;
    public bool isRestart = true;

    private void Update()
    {
        if (isStop)
        {
            t = 0;
            transform.DOPause();
            StopThink();
        }
        else
        {
            if (isRestart)
            {
                isRestart = false;
                transform.DORestart();
            }
            if (isCanTwinkle && isThinking == false)
            {
                Think();
                isThinking = true;
            }
        }
    }

    private void StopThink()
    {
        t+=Time.deltaTime;
        if (t > stopTime)
        {
            isThinking = false;
            isRestart = true;
        }
    }

    private void Think()
    {
        t += Time.deltaTime;
        if(t > thinkTime)
        {
            isStop = true;
        }
    }
}
