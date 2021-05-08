using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpellcasting : MonoBehaviour
{
    // Element_Stage
    // Fire Water Earth
    public short CurrentStage;
    public float LingeringTime;
    public float LingeringTimeMax;
    public bool CanCast;
    public string CurrentElement;
    public GameObject SpellArchives;
    public TextMeshProUGUI castedSpell;
    public TextMeshProUGUI currentElementDisplay;
    private float spellRestingTime;
    private Component SpellIt;
    // public List<string> Element; Do we really need it?
    void Start()
    {
        spellRestingTime = 0f;
        ChangeToFire();
        castedSpell.text = "";
        LingeringTimeMax = 6f;
        CurrentStage = 1;
        LingeringTime = LingeringTimeMax;
        CanCast = true;
    }

    // Update is called once per frame
    void Update()
    {
        float TimeDelta = Time.deltaTime;
        LingeringTime -= TimeDelta;
        spellRestingTime -= TimeDelta;
        if (LingeringTime < 0)
        {
            CurrentStage = 1;
            LingeringTime = LingeringTimeMax;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (CurrentElement)
            {
                case "Fire":
                    ChangeToEarth();
                    break;
                case "Water":
                    ChangeToFire();
                    break;
                case "Earth":
                    ChangeToWater();
                    break;
            }
            
            // Create 

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (CurrentElement)
            {
                case "Fire":
                    ChangeToWater();
                    break;
                case "Water":
                    ChangeToEarth();
                    break;
                case "Earth":
                    ChangeToFire();
                    break;
            }
        }

        if (CanCast)
        {
            if (spellRestingTime < 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CastSpell();
                }
            }
        }
    }

    void CastSpell()
    {
        string currentCastedSpell = CurrentElement + "_" + CurrentStage;

        castedSpell.text = currentCastedSpell;
        SpellArchives.GetComponent<AbilityArchives>().CastSpell(CurrentElement, CurrentStage.ToString());
        CurrentStage++;
        LingeringTime = LingeringTimeMax;

        if (CurrentStage > 3)
        {
            CurrentStage = 1;
        }
        spellRestingTime = SpellArchives.GetComponent<AbilityArchives>().SpellRestingTime;

    }

    void ChangeToWater()
    {
        CurrentElement = "Water";
        currentElementDisplay.text = "Water";
    }
    void ChangeToFire()
    {
        CurrentElement = "Fire";
        currentElementDisplay.text = "Fire";
    }
    void ChangeToEarth()
    {
        CurrentElement = "Earth";
        currentElementDisplay.text = "Earth";
    }
}
