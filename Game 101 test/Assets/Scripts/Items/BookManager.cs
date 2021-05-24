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

    public TextMeshProUGUI description3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToFireLava()
    {
        FireSpellbook3.texture = fireLava;
        description3.text = "Does fire lava things";
    }

    public void ToFireWall()
    {
        FireSpellbook3.texture = fireWall;
        description3.text = "Does fire wall things";
    }
}
