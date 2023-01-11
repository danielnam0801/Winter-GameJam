using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> Mabs = new List<GameObject>();

    private void Start()
    {
        SpawnMap();
    }

    private void SpawnMap()
    {
        for(int i = 0; i < Mabs.Count; i++)
        {
            Instantiate(Mabs[i], new Vector2(i * 14.16f, -6.73F), Quaternion.identity);
        }
    }
}
