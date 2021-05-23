using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GolemBehaviour : EnemyMovement
{
    public GameObject smallGolemPrefab;
    public GameObject boulderPrefab;

    public GameObject rustledGroundGO;

    private bool earthStage = true;
    private bool waterStage;
    private bool fireStage;

    private Animator anim;
    [SerializeField] private GolemAnyStateAnimator animator;

    public GolemAnyStateAnimator Animator
    {
        get { return animator; }
    }

    private void Awake()
    {
        rustledGroundGO.SetActive(false);

        anim = new Animator();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation("Idle"),
            new AnyStateAnimation("Attack01"),
            new AnyStateAnimation("Attack02"),
            new AnyStateAnimation("GetHit"),
            new AnyStateAnimation("Victory"),
            new AnyStateAnimation("Walk"),
            new AnyStateAnimation("Die"),
        };

        animator.AddAnimations(animations);
    }


    void Update()
    {
        if (earthStage)
        {
            EarthStageAttacks();
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

    public void EarthStageAttacks()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            animator.TryPlayAnimation("Attack02"); // "go minions"
            Invoke("Attack_Summon_Golems", 1.5f);

        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            animator.TryPlayAnimation("Victory"); // "roars, ground rumbes"
            Invoke("Attack_Rumble_Ground", 2.5f);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            animator.TryPlayAnimation("Attack01"); // "grunts, swish"
            Invoke("Attack_Rock_Toss", 1.5f);
        }
    }

    void Attack_Summon_Golems()
    {
        Vector2 spawnPos = new Vector2(Random.Range(transform.position.x, transform.position.x - 17), transform.position.y);
        Instantiate(smallGolemPrefab, spawnPos, Quaternion.identity);

        smallGolemPrefab.GetComponent<EnemyMovement>().PlayerGO = PlayerGO;
        smallGolemPrefab.GetComponent<BasicEnemyAI>().PlayerGO = PlayerGO;
        smallGolemPrefab.GetComponent<BasicEnemyAI>().Target = PlayerGO.transform;
    }

    void Attack_Rumble_Ground()
    {
        rustledGroundGO.SetActive(true);
    }

    void Attack_Rock_Toss()
    {
        Vector2 spawnPos = new Vector2(1, 1);
        Vector2 playerPos = new Vector2(PlayerGO.transform.position.x, PlayerGO.transform.position.y);

        var boulder = Instantiate(boulderPrefab, spawnPos, Quaternion.identity);

        boulder.transform.position = Vector2.MoveTowards(spawnPos, playerPos, 4f * Time.deltaTime);
    }
}
