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
            // vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position,
            //                Quaternion.FromToRotation(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f), (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position)));
            //            Quaternion.Euler(0f, 0f, )
            //Quaternion.FromToRotation()
            // CHECK FROM HERE WHY Vfx Spark doesn't work as intended
            //vfx.GetComponent<ProjectileMove>().gameMaster = GameMasterGO;
            /*
            if (rotateToMouse != null)
            { 
                vfx.transform.localRotation = rotateToMouse.GetRotation();
                Debug.Log(vfx.transform.localRotation);
            }
            */

            // TODO: use polymorphism or many methods to destroy objects after some time in different ways (example: water vortex velocity over lifetime starts reducing and vortex "falls down"
            //Destroy(vfx, 5f);

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



}
