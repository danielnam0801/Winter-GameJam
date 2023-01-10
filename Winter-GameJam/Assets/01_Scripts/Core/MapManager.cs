using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> maps = new List<GameObject>();//맵스크립트 담는거로 바꿔줘야할 수도 

    public bool isStageChange;// mapCOllider건드릴때마다 true로 체크해줘야함

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
