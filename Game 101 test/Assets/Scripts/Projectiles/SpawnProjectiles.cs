using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;
    private float timeToFire = 0;

    public Dictionary<string, GameObject> AllSpellVFX;

    private void Start()
    {
       // var prefTemp = Resources.Load("Assets/resources/Prefabs/Spells/FireSpark.prefab", GameObject) as GameObject;
        GameObject prefabTemporary;
        AllSpellVFX = new Dictionary<string, GameObject>();
        prefabTemporary = (GameObject) Resources.Load("Assets/resources/Prefabs/Spells/FireSpark", typeof(GameObject));
        Instantiate(prefabTemporary);
        var muzzleFlashPrefab = (GameObject)Resources.Load("Assets/resources/Prefabs/Spells/FireSpark", typeof(GameObject));
        var AAAAAAAAAAAAAA = GameObject.Instantiate(muzzleFlashPrefab, transform.position, transform.rotation);
        AllSpellVFX.Add("Spell_Fire_Spark", prefabTemporary);
        prefabTemporary = (GameObject)Resources.Load("Assets/resources/Prefabs/Spells/Projectile test", typeof(GameObject));
        AllSpellVFX.Add("Spell_Fire_Bolt", prefabTemporary);
         








    }



    public void SpawnVFX(string key)
    {

        GameObject vfx;

        if (firePoint != null)
        {

            vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position, Quaternion.identity);

            if (rotateToMouse != null)
            { 
                vfx.transform.localRotation = rotateToMouse.GetRotation();


                }
        }
        else
            Debug.Log("No fire point");
    }
}
