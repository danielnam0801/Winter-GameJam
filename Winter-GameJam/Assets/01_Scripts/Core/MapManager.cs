using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> maps = new List<GameObject>();//�ʽ�ũ��Ʈ ��°ŷ� �ٲ������ ���� 

    public bool isStageChange;// mapCOllider�ǵ帱������ true�� üũ�������

    public int currentMapIndex;

    public int MapColliderTouchCount;
    public GameObject nextMap;

    public void Update()
    {
        if(MapColliderTouchCount > maps.Count && isStageChange)
        {
            isStageChange = false;
            ShuffleMap();
        }
    }

    void ShuffleMap()
    {
        
    }
}
