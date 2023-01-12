using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] PlayerMovement moveMent;
    [SerializeField] TextMeshProUGUI distanceText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            { 
                Menu.SetActive(false);
                moveMent.enabled = true;
            }
            else
            {
                Menu.SetActive(true);
                moveMent.enabled = false;
            }
        }
    }

    public void ShowingDistance()
    {
        distanceText.text = gameManager.distanceTraveled.ToString() + "M";
        Debug.Log(gameManager.distanceTraveled.ToString());
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
        moveMent.enabled = true;
    }
}
