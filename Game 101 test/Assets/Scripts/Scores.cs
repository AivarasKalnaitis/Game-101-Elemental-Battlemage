using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Scores : MonoBehaviour
{

    public GameObject SoundMaster;
    public GameObject EndScreen;

    void Awake()
    {
        Time.timeScale = 1f;
    }

    public GameObject FindGameMaster()
    {
        return gameObject;
    }

    public void GameEnd()
    {
        Time.timeScale = 0f;
        EndScreen.SetActive(true);

    }

    
    
}
