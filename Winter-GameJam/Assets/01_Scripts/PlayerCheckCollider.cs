using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckCollider : MonoBehaviour
{
    SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("SP Map").GetComponent<SpawnManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            spawnManager.canSpawnMap = true;
            Destroy(this.gameObject);
        }
    }
}
