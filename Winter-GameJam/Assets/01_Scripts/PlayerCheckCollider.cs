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
                if(collider.transform.position.x < boxCollider.bounds.center.x)//�÷��̾ ���ʿ��� ��
                {
                    spawnManager.currentMapindex = thisMap.mapNum + 1;
                }
                else //�÷��̾ �����ʿ��� ��
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

    private void OnTriggerExit2D(Collider2D collision) //�÷��̾ ��迡�� �Դٰ����ŷ����� ���ɸ��� �����Ŵ������� �˻簡 ���������� true�� ��ȯ �� �� �ְ� �� �ٲ���ߤ���
    {
        if (collision.CompareTag("Player"))
        {
            spawnManager.canCheckMap = false;
        }
    }
}
