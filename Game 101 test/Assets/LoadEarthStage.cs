using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LoadEarthStage : MonoBehaviour
{
    public Volume volume;
    public CanvasGroup canvasGroup;

    public float DeathTime;
    public bool startLoading = false;
    bool loadStage = false;

   
    // Start is called before the first frame update
    void Start()
    {
        DeathTime = 0f;
        volume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startLoading)
        {
            DeathTime += Time.deltaTime;
            volume.weight = DeathTime / 3;
            canvasGroup.alpha = DeathTime / 5;
            Invoke("LoadEarthStageScene", 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        startLoading = true;
    }

    void LoadEarthStageScene()
    {
        SceneManager.LoadScene(2);
    }
}
