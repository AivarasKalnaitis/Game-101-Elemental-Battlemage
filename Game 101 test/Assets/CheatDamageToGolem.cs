using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatDamageToGolem : MonoBehaviour
{
    public GameObject golem;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            golem.GetComponent<EnemyStats>().TakeDamage(150);
        }
    }
}
