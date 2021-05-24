using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenuGameObject;
    public GameObject SettingsMenuGameObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffMainMenu()
    {
        MainMenuGameObject.SetActive(false);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        SettingsMenuGameObject.SetActive(true);
        TurnOffMainMenu();
    }

    public void CreditsButton()
    {

    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);

    }
}
