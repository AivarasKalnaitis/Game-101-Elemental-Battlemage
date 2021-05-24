using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bed : MonoBehaviour
{
    public GameObject door;
    public GameObject PlayerGO;
    private bool enter;
    
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        enter = false;
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (door.GetComponent<E_Open>().insideHouse)
            {
                PlayerGO.GetComponent<PlayerStats>().currentHealth = PlayerGO.GetComponent<PlayerStats>().maxHealth;
            }
        }
    }

    void OnTriggerEnter2D()
    {
        if (door.GetComponent<E_Open>().insideHouse)
        {
            enter = true;
            sprite.enabled = true;
        }
    }

    void OnTriggerExit2D()
    {
        if (door.GetComponent<E_Open>().insideHouse)
        {
            sprite.enabled = false;
            enter = false;
        }
    }
}
