using UnityEngine;

public class DoorsClosing : MonoBehaviour
{
    public GameObject HouseInterior;

    public GameObject HouseExterior;

    public GameObject Letter_E;

    void OnTriggerEnter2D()
    {

        Letter_E.SetActive(true);

    }

    void OnTriggerExit2D()
    {
        Letter_E.SetActive(false);
    }

    void OnTriggerStay2D()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HouseExterior.SetActive(true);
            HouseInterior.SetActive(false);

        }
    }
}
