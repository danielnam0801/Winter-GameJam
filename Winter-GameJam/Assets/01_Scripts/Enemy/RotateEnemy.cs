using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using System.Reflection;

public class RotateEnemy : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject col1;
    public GameObject col2;

    public bool isCanTwinkle = false; // Áß°£¿¡ ºûÀÌ ²¨Áö´Â ¾Ö´Â ¾ê¸¦ Æ®·ç·Î ÇØÁà¾ßÇÔ
    public bool isStop = false;

    private bool isThinking = false;

    [field: SerializeField]
    public bool playerdetected { get; set; } = false;

    public float t = 0;
    public float thinkTime = 7f;

    public float stopTime = 3f;
    public bool isRestart = true;
    private bool isStopthink = false;

    DOTweenAnimation dotween;
    Light2D light2D;

    [Header("ºû")]
    public float lightfallOff;
    private float lightFallOffFirst;

    private static FieldInfo m_FalloffField = typeof(Light2D).GetField("m_FalloffIntensity", BindingFlags.NonPublic | BindingFlags.Instance);

    public void SetFalloff(float falloff)
    {
        m_FalloffField.SetValue(light2D, falloff);
    }

    private void Awake()
    {
        col1 = transform.GetChild(0).gameObject;
        col2 = transform.GetChild(1).gameObject;
    }

    private void Start()
    {
        col1.SetActive(true);
        col2.SetActive(false);
        dotween = GetComponent<DOTweenAnimation>();
        light2D = transform.GetComponentInChildren<Light2D>();
        lightFallOffFirst = light2D.falloffIntensity;
    }

    private void Update()
    {
        if(!playerdetected)
            Check();
        SetFalloff(lightfallOff);
    }

    public void Check()
    {
        if (isStop && isStopthink == false)
        {
            isStopthink = true;
            DOTween.To(()=>lightfallOff, x => lightfallOff = x, 1,1.5f);
            dotween.DOPause();
            Invoke("smallColONOFF", 0.2f);
            StopThink();
        }
        else
        {
            if (isRestart)
            {
                Invoke("BigColONOFF", 0.2f);
                isRestart = false;
                isStopthink = false;
                dotween.DOPlay();
                DOTween.To(() => lightfallOff, x => lightfallOff = x, lightFallOffFirst, 1);
            }
            if (isCanTwinkle && isThinking == false)
            {
                Think();
                isThinking = true;
            }
        }

    }

    public void BigColONOFF()
    {
        if(col1 == null || col2 == null)
        {
            return;
        }
        col1.SetActive(true);
        col2.SetActive(false);
    }
    public void smallColONOFF()
    {
        if (col1 == null || col2 == null)
        {
            return;
        }
        col1.SetActive(false);
        col2.SetActive(true);
    }

    private void StopThink()
    {
        t = 0;
        StartCoroutine(CountStopThink(stopTime));
    }
    private void Think()
    {
        t = 0;
        StartCoroutine(CountThink(thinkTime));
    }

    IEnumerator CountThink(float thinkTIme)
    {
        while (true)
        {
            yield return null;
            t += Time.deltaTime;
            if (t > thinkTIme)
            {
                isStop = true;
                break;
            }
        }
    }

    IEnumerator CountStopThink(float stopTime)
    {
        while (true)
        {
            yield return null;
            t += Time.deltaTime;
            if (t > this.stopTime)
            {
                isThinking = false;
                isRestart = true;
                isStop = false;
                break;
            }
        }
    }

}
