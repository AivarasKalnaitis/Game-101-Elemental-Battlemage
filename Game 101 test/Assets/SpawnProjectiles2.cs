using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnProjectiles2 : MonoBehaviour
{
    public List<GameObject> vfx = new List<GameObject>();
    public Dictionary<string, GameObject> AllSpellVFX;
    public GameObject firePoint;    


    public float offset = -90f;
    // Start is called before the first frame update
    void Start()
    {
        AllSpellVFX = GetVfxDictionary(vfx);

    }


    public void SpawnVFX(string key)
    {

            GameObject vfx;
            Vector3 cursorDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;

            float rot = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot + offset);
            
            vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position, Quaternion.Euler(0f, 0f, rot + offset));
            Debug.Log(rot);

            // TODO: use polymorphism or many methods to destroy objects after some time in different ways (example: water vortex velocity over lifetime starts reducing and vortex "falls down"
            //Destroy(vfx, 5f);

    }

    public Dictionary<string, GameObject> GetVfxDictionary(List<GameObject> vfx)
    {
        return vfx.ToDictionary(x => x.name.ToString(), x => x);
    }



}
