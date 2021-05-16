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
//    public GameObject gameMaster;
    private bool HitAnObject = false;
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
             transform.position += transform.right * (speed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(20);
            if (hitPrefab != null)
            {

                var hitVFX = Instantiate(hitPrefab, gameObject.transform);
                Destroy(gameObject.GetComponent<ParticleSystem>());
                Destroy(gameObject.GetComponent<CircleCollider2D>());

                Destroy(gameObject, 1f);
            }
        }

        if (collision.gameObject.layer == 6)
        {
            if (!HitAnObject)
            {
                var hitVFX = Instantiate(hitPrefab, gameObject.transform);
                Destroy(gameObject.GetComponent<ParticleSystem>());
                Destroy(gameObject.GetComponent<CircleCollider2D>());
                Destroy(gameObject, 1f);
            }
        }
    }
}
