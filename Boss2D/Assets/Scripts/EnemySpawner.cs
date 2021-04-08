using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gm;
    float[] levelDelays = {5.0f, 4.0f, 3.5f};
    int[] levelSpawnNums = {10,15,20};
    float delay = 0.0f;
    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject[] level3;
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Spawn()
    {
        if(gm.level == 0)
        {
            Instantiate(level1[0], transform.position, Quaternion.identity);
        }
        if(gm.level == 1)
        {
            Instantiate(level2[Random.Range(0,1)], transform.position, Quaternion.identity);
        }
        if(gm.level == 2)
        {
            Instantiate(level3[Random.Range(0,2)], transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        delay += Time.deltaTime;
        if((levelDelays[gm.level-1] < delay + Time.deltaTime) & levelSpawnNums[gm.level-1] > 0){
            Spawn();
            levelSpawnNums[gm.level-1]--;
            delay = 0.0f;
        }
        if(levelSpawnNums[gm.level-1] <= 0 & transform.childCount == 0){
            gm.LevelUp();
        }
    }
}
