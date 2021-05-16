using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Assets/Scenes/MenuScene.unity");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());


    }
}
