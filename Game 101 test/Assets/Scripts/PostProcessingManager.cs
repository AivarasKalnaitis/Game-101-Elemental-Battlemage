using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessingManager : MonoBehaviour
{
    public Volume volume;

    public float DeathTime;
    public GameObject GameMasterGO;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        DeathTime = 0f;
        volume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            DeathTime += Time.deltaTime;
            volume.weight = DeathTime / 3;
            if (DeathTime > 3f)
            {
                GameMasterGO.GetComponent<Scores>().GameEnd();
            }
        }
    }

    public void PlayerDeath()
    {

        dead = true;
    }
}
