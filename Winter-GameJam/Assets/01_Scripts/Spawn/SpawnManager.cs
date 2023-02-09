using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int firstSpawnNum = 2;
    [Header("������ �� ����")]
    public List<GameObject> StartSpawnMap = new List<GameObject>();
    public List<GameObject> Mabs = new List<GameObject>();
    [Header("���� Ȱ��ȭ ��")]
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
        for(int i = 0; i < firstSpawnNum; i++)
        {
            Map map;
            
            if(i == 0)
                map = Instantiate(StartSpawnMap[i].GetComponent<Map>());
            else
                map = Instantiate(StartSpawnMap[Random.Range(1, StartSpawnMap.Count + 1)].GetComponent<Map>());

            mapSpawnCnt++;
            map.mapNum = mapSpawnCnt - 1;
            map.gameObject.transform.position = new Vector3((map.mapNum) * xWidth, yWidth, 0); 
            SpawnMabs.Add(map);
            activeMaps.Add(map.gameObject);
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

                Map map = Instantiate(Mabs[RandomMapIndex].GetComponent<Map>());
                map.mapNum = mapSpawnCnt - 1;
                map.gameObject.transform.position = new Vector3(map.mapNum * xWidth, yWidth, 0);
                SpawnMabs.Add(map);
                activeMaps.Add(map.gameObject);
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
