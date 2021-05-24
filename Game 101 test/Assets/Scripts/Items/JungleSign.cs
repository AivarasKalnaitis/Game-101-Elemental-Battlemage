using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JungleSign : MonoBehaviour
{
    public SpriteRenderer sprite;
    private bool canClick;
    void Start()
    {
        canClick = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (canClick)
            {
                SceneManager.LoadScene(1);
            }
        }
    }


    void OnTriggerEnter2D()
    {
        canClick = true;
        sprite.enabled = true;
    }

    void OnTriggerExit2D()
    {
        canClick = false;
        sprite.enabled = false;
    }
}
