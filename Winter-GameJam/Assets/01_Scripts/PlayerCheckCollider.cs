using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckCollider : MonoBehaviour
{
    SpawnManager spawnManager;
    private bool spawnDetect = false;
    Map thisMap;
    BoxCollider2D boxCollider;

    void Start()
    {
        thisMap = transform.GetComponentInParent<Map>();
        spawnManager = GameObject.Find("SP Map").GetComponent<SpawnManager>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player")){
            if (spawnManager.canCheckMap == false)
            {
                spawnManager.canCheckMap = true;
            }
            if(spawnDetect)
            {
                if(collider.transform.position.x < boxCollider.bounds.center.x)//플레이어가 왼쪽에서 들어감
                {
                    spawnManager.currentMapindex = thisMap.mapNum + 1;
                }
                else //플레이어가 오른쪽에서 들어감
                {
                    spawnManager.currentMapindex = thisMap.mapNum;
                }
            }
            else
            {
                spawnManager.currentMapindex = thisMap.mapNum + 1;
                spawnManager.canSpawnMap = true;
                spawnDetect = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //플레이어가 경계에서 왔다갔따거렸을때 렉걸리면 스폰매니저에서 검사가 끝났을때만 true로 변환 할 수 있게 끔 바꿔줘야ㅏㅁ
    {
        if (collision.CompareTag("Player"))
        {
            spawnManager.canCheckMap = false;
        }
    }
}
