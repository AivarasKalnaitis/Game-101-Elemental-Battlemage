using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GolemBehaviour : EnemyMovement
{
    private bool earthStage;
    private bool waterStage;
    private bool fireStage;
    void Update()
    {
        if (earthStage)
        {

        }

        if (waterStage)
        {
                
        }

        if (fireStage)
        {

        }
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerGO.GetComponent<PlayerStats>().TakeDamage(10);
            int direction = 0;
            if (PlayerGO.GetComponent<Transform>().position.x - gameObject.transform.position.x > 0)
                direction = 1;
            else
            {
                direction = -1;
            }
            PlayerGO.GetComponent<PlayerMovement>().canMove = false;
            PlayerGO.GetComponent<PlayerMovement>().Invoke("AllowMovement", 1f);
            PlayerGO.GetComponent<PlayerMovement>().moveInput = direction;
            PlayerGO.GetComponent<PlayerMovement>().jumpRequest = true;
            PlayerGO.GetComponent<PlayerMovement>().extraJumps++;
        }
    }



}
