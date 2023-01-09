using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    private void Update()
    {
        ESC();
    }

    public void ESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.activeSelf)
                Menu.SetActive(false);
            else
                Menu.SetActive(true);
        }
    }
}
