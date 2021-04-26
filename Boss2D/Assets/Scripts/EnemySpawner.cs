using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gm;
    float[] levelDelays = {5.0f, 4.0f, 3.0f};
    int[] levelSpawnNums = {10,13,15};
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
        gm.enemysOnline++;
        if(gm.level == 0)
        {
            Debug.Log("0");
            Instantiate(level1[0], transform.position, Quaternion.identity);
        }
        if(gm.level == 1)
        {
            int i = Random.Range(0,2);
            Debug.Log(i);
            Instantiate(level2[i], transform.position, Quaternion.identity);
        }
        if(gm.level == 2)
        {
            int i = Random.Range(0,3);
            Debug.Log(i);
            Instantiate(level3[i], transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        delay += Time.deltaTime;
        Debug.Log($"Level: {gm.level}");
        if((levelDelays[gm.level] < delay + Time.deltaTime) & levelSpawnNums[gm.level] > 0){
            Spawn();
            levelSpawnNums[gm.level]--;
            delay = 0.0f;
        }
        if(levelSpawnNums[gm.level] <= 0 & gm.enemysOnline <= 0){
            gm.LevelUp();
        }
    }
}
