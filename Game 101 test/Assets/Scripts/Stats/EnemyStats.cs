using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;   
    public string deathAction = "";
    [SerializeField] private LayerMask magicTargets;
    public HealthBar healthBar;
    [SerializeField] private Animator anim;


    void Start()
    {
        currentHealth = maxHealth;
        currentHealth = 1200;
        anim = gameObject.GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector2 mouseDirection =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, mouseDirection, 15f, magicTargets);

            if (hit.collider != null)
            {
                Vector2 targetPos = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                Vector2 playerPos = new Vector2(this.transform.position.x, this.transform.position.y);

                hit.collider.gameObject.transform.position = Vector3.zero;
                this.gameObject.transform.position = targetPos;
                hit.collider.gameObject.transform.position = playerPos;
                //hit.collider.gameObject.transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(50);
        }

    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"currentHealth {currentHealth} damage {damage}");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            // Destroy itself needs animation or something like that
            GivePoints(0);
            //
            DeathAction(deathAction);
        }
    }


    private void DeathAction(string deathAction)
    {
        if (deathAction == "Destroy")
        {
            Debug.Log("poof");

            Destroy(gameObject);
        }
        else
        {   
            anim.Play(deathAction);
        }
    }
    public void GivePoints(int points = 0)
    {

    }

}
