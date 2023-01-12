using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("스폰할 맵 종류")]
    public List<GameObject> StartSpawnMap = new List<GameObject>();
    public List<GameObject> Mabs = new List<GameObject>();
    [Header("실제 활성화 맵")]
    public List<GameObject> activeMaps = new List<GameObject>();
    public List<Map> SpawnMabs = new List<Map>();

    [SerializeField] private float xWidth = 14.16f;
    [SerializeField] private float yWidth = -6.73f;

    public int mapSpawnCnt = 0;

    public bool canSpawnMap = false;
    public int currentMapindex = 0; 

    GameManager gameManger;
    public bool canCheckMap = false;

    private void Start()
    {
        StartCoroutine("MapSpawn");
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator MapSpawn()
    {
        for(int i = 0; i < StartSpawnMap.Count; i++)
        {
            mapSpawnCnt++;
            Map map = StartSpawnMap[i].GetComponent<Map>();
            map.mapNum = mapSpawnCnt - 1;
            map.gameObject.transform.position = new Vector3((map.mapNum) * xWidth, yWidth, 0); 
            SpawnMabs.Add(map);
            activeMaps.Add(Instantiate(map.gameObject));
        }
        yield return null;
        while (true)
        {
            if (gameManger.EndGame)
            {
                Debug.Log("EndGame");
                break;
            }
            if (canSpawnMap == true)
            {
                canSpawnMap = false;

                mapSpawnCnt++;
                int RandomMapIndex = UnityEngine.Random.Range(0,Mabs.Count);

                Map map = Mabs[RandomMapIndex].GetComponent<Map>();
                map.mapNum = mapSpawnCnt - 1;
                map.gameObject.transform.position = new Vector3(map.mapNum * xWidth, yWidth, 0);
                SpawnMabs.Add(map);
                activeMaps.Add(Instantiate(map.gameObject));
            }
            if (canCheckMap)
            {
                foreach (Map maps in SpawnMabs)
                {
                    if (activeMaps[maps.mapNum].activeSelf == true)
                    {
                        if (maps.mapNum < currentMapindex - 2 || maps.mapNum > currentMapindex + 2)
                        {
                            if(maps.mapNum >= 0)
                                activeMaps[maps.mapNum].SetActive(false);
                        }
                    }
                    else
                    {
                        if (maps.mapNum >= currentMapindex - 2 && maps.mapNum <= currentMapindex + 2)
                        {
                            activeMaps[maps.mapNum].SetActive(true);
                        }
                    }
                }
            }

            yield return null;
        }
    }

}
