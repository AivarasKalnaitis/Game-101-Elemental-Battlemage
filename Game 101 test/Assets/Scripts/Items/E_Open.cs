using UnityEngine;

public class E_Open : MonoBehaviour
{
    public GameObject HouseInterior;
    public GameObject HouseExterior;

    public GameObject Bed_E;
    public GameObject Book_E;
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
        if (Input.GetKeyDown(KeyCode.E))
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
    