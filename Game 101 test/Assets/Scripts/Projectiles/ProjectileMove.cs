using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;

    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    private void Start()
    {
        if(muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
        }
    }

    void Update()
    {
        if (speed != 0)
            transform.position += transform.forward * (speed * Time.deltaTime);
        else
            Debug.Log("No speed");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;

        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
        Vector2 pos = contact.point;

        if(hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
        }

        Destroy(gameObject);
    }
}
