using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject SlimePrefab;
    public float spawnTimer = 3f;
    public GameObject PlayerGO;

    void Start()
    {
        Invoke("SpawnEnemySlime", spawnTimer);
    }


    void Update()
    {
        
    }

    public void SpawnEnemySlime()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-17, 17), Random.Range(0, 17));
        Instantiate(SlimePrefab, spawnPos, Quaternion.identity);
        SlimePrefab.GetComponent<EnemyMovement>().PlayerGO = PlayerGO;
        SlimePrefab.GetComponent<BasicEnemyAI>().PlayerGO = PlayerGO;
        SlimePrefab.GetComponent<BasicEnemyAI>().Target = PlayerGO.transform;
//        SlimePrefab.GetComponent<EnemyStats>(). 
        Invoke("SpawnEnemySlime", spawnTimer);
    }
}
