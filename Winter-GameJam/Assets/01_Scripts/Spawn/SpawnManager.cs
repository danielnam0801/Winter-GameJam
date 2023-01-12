using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> StartMabs = new List<GameObject>();
    public List<GameObject> Mabs = new List<GameObject>();

    [SerializeField] private float xWidth = 14.16f;
    [SerializeField] private float yWidth = -6.73f;

    public int mapSpawnCnt = 0;

    public bool canSpawnMap = false;

    GameManager gameManger;

    private void Start()
    {
        StartCoroutine("MapSpawn");
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator MapSpawn()
    {
        for(int i = 0; i < StartMabs.Count; i++)
        {
            mapSpawnCnt++;
            Instantiate(StartMabs[i], new Vector2(i * xWidth, yWidth), Quaternion.identity);
        }
        yield return null;
        while (true)
        {
            if (gameManger.EndGame)
            {
                break;
            }
            if (canSpawnMap == true)
            {
                canSpawnMap = false;
                int RandomMapIndex = UnityEngine.Random.Range(0,Mabs.Count);
                mapSpawnCnt++;
                Instantiate(Mabs[RandomMapIndex], new Vector2((mapSpawnCnt - 1) * xWidth, yWidth), Quaternion.identity);
            }

            yield return null;
        }
    }

}
