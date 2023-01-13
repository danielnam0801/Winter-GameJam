using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightInitScript : MonoBehaviour
{
    Light2D light2d;
    float firstintensity = 0.58f;
    private void Awake()
    {
        light2d = GetComponent<Light2D>();
        light2d.intensity = 0;
    }

    private void Start()
    {
        StartCoroutine("LightTwinkle");            
    }

    IEnumerator LightTwinkle()
    {
        yield return new WaitForSeconds(2f);
        float t = 0;
        while(light2d.intensity < firstintensity)
        {
            if (t > 1)
            {
                break;
            }
            t+=Time.deltaTime;
            light2d.intensity = Mathf.Lerp(light2d.intensity, firstintensity, t);
            Debug.Log("Light");
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        while (true)
        {
            light2d.intensity = Random.Range(firstintensity,firstintensity+0.1f);
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            light2d.intensity = 0;
            yield return new WaitForSeconds(Random.Range(0.5f,1f));
        }
    }

    


}
