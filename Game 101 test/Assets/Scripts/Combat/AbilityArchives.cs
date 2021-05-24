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
        PreparedSpells.Add("Water_1", "Spell_Water_Bubble");
        PreparedSpells.Add("Water_2", "Spell_Ice_Spikes");
        PreparedSpells.Add("Water_3", "Spell_Water_Vortex");
        PreparedSpells.Add("Earth_1", "Spell_Rock_Splash");
        PreparedSpells.Add("Earth_2", "Spell_Rock_Toss");
        PreparedSpells.Add("Earth_3", "Spell_Planetary_Devastation");

        VfxList = GetComponent<SpawnProjectiles2>().AllSpellVFX;
    }

    void Update()
    {
        
    }


    public void CastSpell(string element, string stage)
    {
        SpellKey = element + "_" + stage;

        Invoke(PreparedSpells[SpellKey], 0f);
    }

    private void Spell_Fire_Spark()
    {
        SpellRestingTime = 1f;
        
        spellTemp.text = "Spell Fire Spark";
        gameObject.GetComponent<SpawnProjectiles2>().SpawnVFX("Spell_Fire_Spark");
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey]);   
    }

    private void Spell_Water_Bubble()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Water_Splash";
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey]);
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
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey]);

    }

    private void Spell_Ice_Spikes()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Ice_Spikes";
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey], 10f, 1.5f);
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
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey], 10f, 4f);

    }

    private void Spell_Water_Vortex()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Water_Vortex";
        Debug.Log(SpellKey);
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey], 10f, 2f);

    }

    private void Spell_Planetary_Devastation()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Planetary_Devastation";
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey]);
    }

    private void Spell_Lava_Ground()
    {
        SpellRestingTime = 1f;
        spellTemp.text = "Spell_Lava_Ground";
        GetComponent<SpawnProjectiles2>().SpawnVFX(PreparedSpells[SpellKey], 10f, 2f);  
    }
}
