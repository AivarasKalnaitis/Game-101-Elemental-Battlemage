using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public RawImage FireSpellbook3;
    public Texture2D fireWall;
    public Texture2D fireLava;
    public List<GameObject> BookPages;
    public TextMeshProUGUI description3;
    private int currentPageIndex;
    private int maxPageIndex;
    public GameObject SpellArchives;

    void Start()
    {
       // BookPages = new List<GameObject>();
        maxPageIndex = 2;
        currentPageIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPageIndex <= 0)
            {
                currentPageIndex = 2;
            }
            else
            {
                currentPageIndex--;
            }
            DisableEveryPage();
            BookPages[currentPageIndex].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPageIndex >= maxPageIndex)
            {
                currentPageIndex = 0;
            }
            else
            {
                currentPageIndex++;
            }
            DisableEveryPage();
            BookPages[currentPageIndex].SetActive(true);
        }

    }

    public void ToFireLava()
    {
        FireSpellbook3.texture = fireLava;
        description3.text = "Does fire lava things";
        SpellArchives.GetComponent<AbilityArchives>().PreparedSpells["Fire_3"] = "Spell_Lava_Ground";
        SpellArchives.GetComponent<SpawnProjectiles2>().TakeDictionary();
    }

    private void DisableEveryPage()
    {
        for (int i = 0; i <= maxPageIndex; i++)
        {
            BookPages[i].SetActive(false);
        }
    }
    public void ToFireWall()
    {
        FireSpellbook3.texture = fireWall;
        description3.text = "Does fire wall things";
        SpellArchives.GetComponent<AbilityArchives>().PreparedSpells["Fire_3"] = "Spell_Fire_Wall";

        SpellArchives.GetComponent<SpawnProjectiles2>().TakeDictionary();   


    }
}
