using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;
    public GameObject GameMasterGO;
    private float timeToFire = 0;

    public Dictionary<string, GameObject> AllSpellVFX;

    private void Start()
    {
//       // var prefTemp = Resources.Load("Assets/resources/Prefabs/Spells/FireSpark.prefab", GameObject) as GameObject;
//        GameObject prefabTemporary;
//        AllSpellVFX = new Dictionary<string, GameObject>();
//        prefabTemporary = (GameObject) Resources.Load("Assets/resources/Prefabs/Spells/FireSpark", typeof(GameObject));
//        Instantiate(prefabTemporary);
//        var muzzleFlashPrefab = (GameObject)Resources.Load("Assets/resources/Prefabs/Spells/FireSpark", typeof(GameObject));
//        var AAAAAAAAAAAAAA = GameObject.Instantiate(muzzleFlashPrefab, transform.position, transform.rotation);
//        AllSpellVFX.Add("Spell_Fire_Spark", prefabTemporary);
//        prefabTemporary = (GameObject)Resources.Load("Assets/resources/Prefabs/Spells/Projectile test", typeof(GameObject));
//        AllSpellVFX.Add("Spell_Fire_Bolt", prefabTemporary);

        AllSpellVFX = GetVfxDictionary(vfx);

//        foreach (KeyValuePair<string, GameObject> kvp in AllSpellVFX)
//        {
//            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
//        }
    }

    public Dictionary<string, GameObject> GetVfxDictionary(List<GameObject> vfx)
    {
        //Dictionary<string, GameObject> PreparedSpells = new Dictionary<string, GameObject>();
        //foreach (GameObject effect in vfx)
        //{
        //    PreparedSpells.Add(effect.name, effect);
        //}



        //return 0;
        return vfx.ToDictionary(x => x.name.ToString(), x => x);

    }



    public void SpawnVFX(string key)
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position, Quaternion.identity);
            // CHECK FROM HERE WHY Vfx Spark doesn't work as intended
            //vfx.GetComponent<ProjectileMove>().gameMaster = GameMasterGO;
            
            if (rotateToMouse != null)
            { 
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }

            // TODO: use polymorphism or many methods to destroy objects after some time in different ways (example: water vortex velocity over lifetime starts reducing and vortex "falls down"
            Destroy(vfx, 5f);
        }
        else
            Debug.Log("No fire point");
    }


}
