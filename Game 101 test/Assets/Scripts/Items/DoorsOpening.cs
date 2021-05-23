using UnityEngine;

public class DoorsOpening : MonoBehaviour
{
    public GameObject HouseInterior;

    public GameObject HouseExterior;

    public GameObject Letter_E;

    void OnTriggerEnter2D()
    {

        Letter_E.SetActive(true);
        Debug.Log("HEH?E");

    }

    void OnTriggerExit2D()
    {
        Debug.Log("HEH?X");

        Letter_E.SetActive(false);
    }

    void OnTriggerStay2D()
    {   
        Debug.Log("HEH?");
        if (Input.GetKeyDown(KeyCode.E))
        {
            HouseInterior.SetActive(true);
            HouseExterior.SetActive(false);
        }
    }
}
