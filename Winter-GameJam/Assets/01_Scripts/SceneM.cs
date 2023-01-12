using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] string SceneName;

    public void SceneMove()
    {
        StartCoroutine(MoveScene());
    }

    IEnumerator MoveScene()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneName);
    }
}
