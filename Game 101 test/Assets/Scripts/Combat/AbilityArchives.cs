using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityArchives : MonoBehaviour
{
    public GameObject PlayerGO;
    private int currentStage;
    private string currentElement;
    public Dictionary<string, string> PreparedSpells;
    public TextMeshProUGUI spellTemp;
    public float SpellRestingTime;
//    private List<GameObject> VfxList;
    private Dictionary<string, GameObject> VfxList;
    private string SpellKey;

    void Start()
    {
        //        VfxList = this.gameObject.GetComponent<SpawnProjectiles>().vfx;
        //
                SpellRestingTime = 0f;
        //        currentStage = PlayerGO.GetComponent<PlayerSpellcasting>().CurrentStage;
        //        currentElement = PlayerGO.GetComponent<PlayerSpellcasting>().CurrentElement;
        PreparedSpells = new Dictionary<string, string>();
        PreparedSpells.Add("Fire_1", "Spell_Fire_Spark");
        PreparedSpells.Add("Fire_2", "Spell_Fire_Bolt");
        PreparedSpells.Add("Fire_3", "Spell_Fire_Wall");
        PreparedSpells.Add("Water_1", "Spell_Water_Splash");
        PreparedSpells.Add("Water_2", "Spell_Water_Bounce");
        PreparedSpells.Add("Water_3", "Spell_Water_Vortex");
        PreparedSpells.Add("Earth_1", "Spell_Rock_Splash");
        PreparedSpells.Add("Earth_2", "Spell_Rock_Toss");
        PreparedSpells.Add("Earth_3", "Spell_Planetary_Devastation");


        //PreparedSpells < "Fire_1" > = new "Spell_Fire_Spark";

        VfxList = GetComponent<SpawnProjectiles>().AllSpellVFX;
        Debug.Log(VfxList);




    }

    void Update()
    {
        
    }


    public void CastSpell(string element, string stage)
    {
        SpellKey = element + "_" + stage;
        //SpellKey = ;

        Debug.Log(SpellKey);
        Invoke(PreparedSpells[SpellKey], 0f);


    }

    private void Spell_Fire_Spark()
    {
        SpellRestingTime = 1f;
        
        spellTemp.text = "Spell Fire Spark";
        gameObject.GetComponent<SpawnProjectiles>().SpawnVFX("Spell_Fire_Spark");
        GetComponent<SpawnProjectiles>().SpawnVFX(PreparedSpells[SpellKey]);
    }

    private void Spell_Water_Splash()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Water_Splash";
        //Instantiate(VfxList[spellKey]);
    }

    private void Spell_Rock_Splash()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Rock_Splash";
        //         GetComponent<SpawnProjectiles>().SpawnVFX(SpellKey);
    }

    private void Spell_Fire_Bolt()
    {   
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Fire_Bolt";
        //gameObject.GetComponent<SpawnProjectiles>().SpawnVFX("Spell_Fire_Bolt");
        GetComponent<SpawnProjectiles>().SpawnVFX(PreparedSpells[SpellKey]);

    }

    private void Spell_Water_Bounce()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Water_Bounce";
        //        GetComponent<SpawnProjectiles>().SpawnVFX(SpellKey);

    }

    private void Spell_Rock_Toss()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Rock_Toss";
        //        GetComponent<SpawnProjectiles>().SpawnVFX(SpellKey);

    }

    private void Spell_Fire_Wall()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Fire_Wall";
        //        GetComponent<SpawnProjectiles>().SpawnVFX(SpellKey);

    }

    private void Spell_Water_Vortex()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Water_Vortex";
        //        GetComponent<SpawnProjectiles>().SpawnVFX(SpellKey);

    }

    private void Spell_Planetary_Devastation()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Planetary_Devastation";
        //        GetComponent<SpawnProjectiles>().SpawnVFX(SpellKey);

    }
}
