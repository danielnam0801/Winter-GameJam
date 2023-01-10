using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject CurrentScoreButton;
    [SerializeField] TextMeshProUGUI distanceText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        ESC();
        ShowingDistance();
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

    public void ShowingDistance()
    {
        distanceText.text = gameManager.distanceTraveled.ToString() + "M";
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
}
