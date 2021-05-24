using UnityEngine;

public class E_Open : MonoBehaviour
{
    public GameObject HouseInterior;
    public GameObject HouseExterior;
    public bool insideHouse;

    private bool enter;
    private SpriteRenderer sprite;
    public AudioSource audio;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        enter = false;
        insideHouse = false;
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (enter)
            {
                if (!insideHouse)
                {
                    HouseInterior.SetActive(true);
                    HouseExterior.SetActive(false);
                    insideHouse = true;
                }
                else if (insideHouse)
                {
                    HouseInterior.SetActive(false);
                    HouseExterior.SetActive(true);
                    insideHouse = false;    
                }
                audio.Play();
            }
        }
    }

    void OnTriggerEnter2D()
    {
        sprite.enabled = true;
        enter = true;
    }

    void OnTriggerExit2D()
    {
        sprite.enabled = false;
        enter = false;
    }
}
    