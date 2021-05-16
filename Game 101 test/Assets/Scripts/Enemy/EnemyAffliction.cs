using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAffliction : EnemyMovement   
{
    [SerializeField] private float vortexApplicableTimer;
    [SerializeField] private float vortexApplicableMaxTimer;
    public bool vortexApplicable;

    void Start()
    {
        vortexApplicableMaxTimer = 0.3f;
        AffectedByVortex = false;
        wantsToMove = false;
        vortexApplicableTimer = vortexApplicableMaxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (AffectedByVortex)
        {
            AddForceToIt();
        }

        if (vortexApplicable)
        {
            vortexApplicableTimer -= Time.deltaTime;
            if (vortexApplicableTimer < 0)
            {
                gameObject.GetComponent<EnemyStats>().TakeDamage(20);
                vortexApplicable = false;
                vortexApplicableTimer = vortexApplicableMaxTimer;
            }
        }
    }
}
