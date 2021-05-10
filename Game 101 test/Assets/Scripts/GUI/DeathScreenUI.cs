using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Assets/Scenes/MenuScene.unity");
    }

    public void Restart()
    {
        Debug.Log("RER");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Assets/Scenes/Bloodbath_1.unity");


    }
}
