using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;

    private void Start()
    {
        effectToSpawn = vfx[0];
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);

            if (rotateToMouse != null)
                vfx.transform.localRotation = rotateToMouse.GetRotation();
        }
        else
            Debug.Log("No fire point");
    }
}
