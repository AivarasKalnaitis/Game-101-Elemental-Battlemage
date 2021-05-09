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

    
    
}
