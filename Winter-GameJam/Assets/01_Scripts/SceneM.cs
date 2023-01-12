using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    [SerializeField] float time;

    public void SceneMove(string scene)
    {
        StartCoroutine(MoveScene(scene));
    }

    IEnumerator MoveScene(string scene)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
