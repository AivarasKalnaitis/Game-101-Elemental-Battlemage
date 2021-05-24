using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnProjectiles2 : MonoBehaviour
{
    public List<GameObject> vfx = new List<GameObject>();
    public Dictionary<string, GameObject> AllSpellVFX;
    public GameObject firePoint;
    public LayerMask groundCheck;

    public float offset = -90f;
    // Start is called before the first frame update
    void Start()
    {
        TakeDictionary();
    }

    public void TakeDictionary()
    {
        AllSpellVFX = GetVfxDictionary(vfx);
    }


    public void SpawnVFX(string key, string summoningType = "projectile")
    {
            //GameObject vfx;
            Vector3 cursorDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;
            
            float rot = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot + offset);

        //vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position, Quaternion.Euler(0f, 0f, rot + offset));
        // Spell_Fire_Wall(key, "kew");
//        StationaryGroundSpell(key, 10f, 4f);
        // TODO: use polymorphism or many methods to destroy objects after some time in different ways (example: water vortex velocity over lifetime starts reducing and vortex "falls down"
        //Destroy(vfx, 5f);
    }

    public void SpawnVFX(string key)
    {
        GameObject vfx;
        Vector3 cursorDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;

        float rot = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot + offset);

        vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position, Quaternion.Euler(0f, 0f, rot + offset));
    }


    public void SpawnVFX(string key, float maxDistance, float fromWallDistance)
    {
        Vector3 cursorPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int direction;
        if (cursorPoint.x > firePoint.transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        Vector2 spawnPoint = new Vector2(0f, firePoint.transform.position.y + 1);
        Vector2 dir = cursorPoint - firePoint.transform.position;
        RaycastHit2D wallHit = Physics2D.Raycast(firePoint.transform.position, dir, maxDistance + fromWallDistance, groundCheck);
        if (wallHit.collider != null)
        {
            spawnPoint.x = wallHit.point.x - (fromWallDistance * direction);
        }
        else if(Mathf.Abs(cursorPoint.x - firePoint.transform.position.x) < maxDistance)
        {
            spawnPoint.x = cursorPoint.x;
        }
        else
        {
            spawnPoint.x = firePoint.transform.position.x + (maxDistance * direction); 
        }
        RaycastHit2D checkBottomGround = Physics2D.Raycast(spawnPoint, Vector2.down, maxDistance, groundCheck);
        spawnPoint = checkBottomGround.point;
        GameObject vfx = Instantiate(AllSpellVFX[key], spawnPoint, Quaternion.identity);

    }

    public Dictionary<string, GameObject> GetVfxDictionary(List<GameObject> vfx)
    {
        return vfx.ToDictionary(x => x.name.ToString(), x => x);
    }



}
