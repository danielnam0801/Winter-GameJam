using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartScene : MonoBehaviour
{
    [SerializeField] float Stoptime;
    [SerializeField] float Starttime;

    [SerializeField] GameObject obj;

    void Start()
    {
   
    }

    public void StopThing()
    {
        StartCoroutine(thingStop());
    }

    IEnumerator thingStop()
    {
        yield return new WaitForSeconds(Stoptime);
        obj.SetActive(false);
    }

    public void StartThing()
    {
        StartCoroutine(thingStart());
    }

    IEnumerator thingStart()
    {
        yield return new WaitForSeconds(Starttime);
        obj.SetActive(true);
    }
}
