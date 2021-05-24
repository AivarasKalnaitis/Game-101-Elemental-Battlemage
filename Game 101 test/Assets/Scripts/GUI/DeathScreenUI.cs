using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject deathscreen;

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

    public void RefillHP()
    {
        playerStats.currentHealth = 100;
        deathscreen.SetActive(false);
    }
}
