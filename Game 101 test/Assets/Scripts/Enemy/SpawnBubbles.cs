using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubbles : MonoBehaviour
{
    public float spawnTimer;
    public float spawnTimerMax = 5f;
    public GameObject bubbleToSpawn;

    void Start()
    {
        spawnTimer = spawnTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            SpawnBubble();
            spawnTimer = spawnTimerMax;
        }
    }

    void SpawnBubble()
    {
        Vector3 xy = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y + Random.Range(0,2f), 0f);
        Instantiate(bubbleToSpawn, xy, Quaternion.identity);
    }
}
