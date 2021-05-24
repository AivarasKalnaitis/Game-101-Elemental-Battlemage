using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallDamageToGolem : MonoBehaviour
{
    public EnemyStats enemyStats;
    private List<float> DealDamage;
    private float damageIntervalTime;
    private float damageIntervalTimeMax;
    private bool dealDamage;
    void Start()
    {
//        dealDamage = false;
//        damageIntervalTimeMax = 0.25f;
//        damageIntervalTime = damageIntervalTimeMax;
        Destroy(gameObject, 3f);


    }

    void Update()
    {
//        damageIntervalTime -= Time.deltaTime;

    }
//
//    void DealDamages(Collider2D other, float time)
//    {
//        if (dealDamage && damageIntervalTime < 0)
//        {
//            other.gameObject.GetComponent<EnemyStats>().TakeDamage(5);
//            DealDamages(other, time);
//            damageIntervalTime = damageIntervalTimeMax;
//        }
//    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 9)
        {
//            dealDamage = true;
//            DealDamages(other, 0.25f);
            other.gameObject.GetComponent<EnemyStats>().TakeDamage(20);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dealDamage = false;
    }
    
}
