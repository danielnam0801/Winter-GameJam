using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Define : MonoBehaviour
{
    private static Camera _mainCam = null;

    public static Camera MainCam
    {
        get
        {
            if (_mainCam == null)
                _mainCam = Camera.main;
            return _mainCam;
        }

    }
    private static CinemachineVirtualCamera _cmVCam = null;
    public static CinemachineVirtualCamera VCam
    {
        get
        {
            if (_cmVCam == null)
                _cmVCam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            return _cmVCam;
        }
    }

    public static LayerMask Ground = 1 << 10;
    public static LayerMask Player = 1 << 6;
}
