using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject PPM; // Post Processing Manager
    public int currentHealth;

    [SerializeField]
    private LayerMask magicTargets;
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
            Vector2 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
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

        Vector3 cursorPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(cursorPoint);

    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            while(currentHealth != maxHealth)
            {
                currentHealth += 5;
            }
        }
    }

    public void PlayerDeath()
    {
        PPM.GetComponent<PostProcessingManager>().PlayerDeath();
    }

    public void UseMagicAbility()
    {
        Vector2 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.gameObject.transform.position.x + 1, this.gameObject.transform.position.y), mouseDirection);
        if (hit.collider.gameObject.layer >= 9 && hit.collider.gameObject.layer <= 11)
        {
            Vector2 targetPos = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
            Vector2 playerPos = new Vector2(this.transform.position.x, this.transform.position.y);

            hit.collider.gameObject.transform.position = Vector3.zero;
            this.gameObject.transform.position = targetPos;
            hit.collider.gameObject.transform.position = playerPos;
        }
    }
}
