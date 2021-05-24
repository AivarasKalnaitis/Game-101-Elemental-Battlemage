using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] private LayerMask magicTargets;
    public HealthBar healthBar;
    public GolemAnyStateAnimator anim;
    public GameObject devastationPrefab;
    public Volume volume;
    bool startLoadingWater = false;
    bool startLoadingFire = false;
    float DeathTime;
    public GolemBehaviour golemBehaviour;
    public CanvasGroup canvasGroup;

    public GameObject spellPagePrefab;

    void Start()
    {
        currentHealth = maxHealth;
        currentHealth = 400;
        healthBar.SetMaxHealth(maxHealth);
        DeathTime = 0f;
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

        if (startLoadingWater)
        {
            DeathTime += Time.deltaTime;
            volume.weight = DeathTime / 1.2f;
            Invoke("LoadWaterStageScene", 8f);
        }
        else if(startLoadingFire)
        {
            DeathTime += Time.deltaTime;
            canvasGroup.alpha = DeathTime / 2f;
            volume.weight = DeathTime / 3f;
            Invoke("LoadFireStageScene", 4f);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"currentHealth {currentHealth} damage {damage}");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            DeathAction();
        }
    }


    private void DeathAction()
    {
        anim.TryPlayAnimation("Die");

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Vector2 pos = new Vector2(-4, -2);
            Instantiate(devastationPrefab, pos, Quaternion.identity);
            Invoke("SetStartLoadingWater", 5f);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            Invoke("SetStartLoadingFire", 3f);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            Vector2 pos = new Vector2(25f, -3.5f);
            Instantiate(spellPagePrefab, pos, Quaternion.identity);
        }

    }

    void LoadWaterStageScene()
    {
        SceneManager.LoadScene(3);
    }

    void LoadFireStageScene()
    {
        SceneManager.LoadScene(4);
    }

    void SetStartLoadingWater()
    {
        startLoadingWater = true;
    }

    void SetStartLoadingFire()
    {
        startLoadingFire = true;
    }
}
