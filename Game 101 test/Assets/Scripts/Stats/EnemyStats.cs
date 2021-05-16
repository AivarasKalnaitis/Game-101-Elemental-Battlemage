using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] private LayerMask magicTargets;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
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

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            // Destroy itself needs animation or something like that
            GivePoints(0);
            Destroy(gameObject);
        }
    }

    public void GivePoints(int points = 0)
    {

    }

}
