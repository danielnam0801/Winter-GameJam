using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject CurrentScoreButton;
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

    public void ExitGame()
    {
        StartCoroutine(GameExit());
    }
    IEnumerator GameExit()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
        Debug.Log("게임 나가기");
    }

    public void Continue()
    {
        StartCoroutine(ContinueTime());
    }
    IEnumerator ContinueTime()
    {
        yield return new WaitForSeconds(0.6f);
        Menu.SetActive(false);
    }

    public void ScoreMove()
    {
        
    }
}
