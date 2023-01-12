using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineEffect : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] CinemachineBasicMultiChannelPerlin a;

    private void Awake()
    {
        cam = Define.VCam;
        a = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CinemachineInit(0,0);
    }


    public void CinemachineInit(float amp,float Fre)
    {
        a.m_AmplitudeGain = amp;
        a.m_FrequencyGain = Fre;
    }

    public void CinemaZero()
    {
        StartCoroutine("ZeroEvent");
    }
    public void RobotAppearWaitShakeCinema()
    {
        CinemachineInit(1, 1);
    }

    IEnumerator ZeroEvent()
    {
        a.m_AmplitudeGain = Mathf.Lerp(a.m_AmplitudeGain, 0, 1);
        a.m_FrequencyGain = Mathf.Lerp(a.m_FrequencyGain, 0, 1);
        yield return new WaitUntil(()=>(a.m_AmplitudeGain == 0 && a.m_FrequencyGain == 0));
    }
}
