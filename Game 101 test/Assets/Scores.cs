using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private int totalScore = 0;
    public GameObject SoundMaster;
    public TextMeshProUGUI pointsText;
    public GameObject EndScreen;

    void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        pointsText.text = totalScore.ToString();
    }
    public void AddPoint(int points)
    {
        totalScore += points;
        pointsText.text = totalScore.ToString();
        SoundMaster.GetComponent<SoundManager>().Slime_Death.Play();
    }

    public GameObject FindGameMaster()
    {
        return gameObject;
    }

    public void GameEnd()
    {
        Time.timeScale = 0.02f;
        EndScreen.SetActive(true);

    }
    
    
}
