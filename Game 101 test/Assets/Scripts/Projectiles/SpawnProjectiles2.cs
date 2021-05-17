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


    public void SpawnVFX(string key, string summoningType = "projectile")
    {
            GameObject vfx;
            Vector3 cursorDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;
            
            float rot = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot + offset);
            
            vfx = Instantiate(AllSpellVFX[key], firePoint.transform.position, Quaternion.Euler(0f, 0f, rot + offset));
              // Spell_Fire_Wall(key, "kew");

            // TODO: use polymorphism or many methods to destroy objects after some time in different ways (example: water vortex velocity over lifetime starts reducing and vortex "falls down"
            //Destroy(vfx, 5f);
    }

    
    private void Spawn(string key, string summoning)
    {

    }
    private void Spell_Fire_Wall(string key, string summoning)
    {
        float spellDistance = 10f;
        int direction;

        Vector3 cursorDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;
        Vector3 cursorPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (cursorDirection.x > 0){direction = 1;}
        else{direction = -1;}
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(firePoint.transform.position.x + direction, firePoint.transform.position.y), cursorPoint, spellDistance);
        RaycastHit2D wallCheck = Physics2D.Raycast(new Vector2(firePoint.transform.position.x + direction, firePoint.transform.position.y), cursorDirection, spellDistance + 4f);
        Vector2 spawnPosition = new Vector2(0f, 0f);
        RaycastHit2D groundFinder;
        if (wallCheck.collider != null)
        {
            if (wallCheck.collider.gameObject.layer == 6)
            {
                spawnPosition.x = wallCheck.transform.position.x - (4f * direction);
            }
        }
        else
        {

            spawnPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if (spawnPosition.x > 10)
            {
                spawnPosition.x = firePoint.transform.position.x + (10f * direction);
            }
        }

        groundFinder = Physics2D.Raycast(new Vector2(spawnPosition.x, firePoint.transform.position.y), Vector2.down, 20f);

        if (groundFinder.collider != null)
        {
            if (groundFinder.collider.gameObject.layer == 6)
            {
                GameObject vfx = Instantiate(AllSpellVFX[key], groundFinder.collider.transform.position, Quaternion.identity);
            }
        }


    }

    public Dictionary<string, GameObject> GetVfxDictionary(List<GameObject> vfx)
    {
        return vfx.ToDictionary(x => x.name.ToString(), x => x);
    }



}
