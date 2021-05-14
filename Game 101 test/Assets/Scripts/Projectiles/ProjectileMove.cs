using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;
    public GameObject gameMaster;

    public int pointsForSlime = 100;

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
        // čia tai geras šūdas
        // var hitVFX = Instantiate(hitPrefab, transform.position, Quaternion.identity);

        if (speed != 0)
            //transform.position += transform.forward * (speed * Time.deltaTime);
             transform.position += transform.forward * (speed * Time.deltaTime);

        else
            Debug.Log("No speed");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;
        ContactPoint2D contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector2.up, contact.normal);
        Vector2 pos = contact.point;
        
        if(hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject); 
            gameMaster.GetComponent<Scores>().AddPoint(pointsForSlime);
        }

        Destroy(gameObject);
    }
}
