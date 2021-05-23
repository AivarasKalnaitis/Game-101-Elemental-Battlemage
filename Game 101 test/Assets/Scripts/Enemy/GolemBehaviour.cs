using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GolemBehaviour : EnemyMovement
{
    public GameObject smallGolemPrefab;
    public GameObject boulderPrefab;
    public GameObject snowballPrefab;

    public GameObject rustledGroundGO;
    public GameObject iceSpikesLeft;
    public GameObject iceSpikesRight;

    private bool earthStage = false;
    private bool waterStage = true;
    private bool fireStage;

    private Animator anim;
    [SerializeField] private GolemAnyStateAnimator animator;

    public GolemAnyStateAnimator Animator
    {
        get { return animator; }
    }

    private void Awake()
    {
        if(earthStage)
        {
            rustledGroundGO.SetActive(false);
        }

        if(waterStage)
        {
            iceSpikesLeft.SetActive(false);
            iceSpikesRight.SetActive(false);
        }

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
            WaterStageAttacks();
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

    void WaterStageAttacks()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
             // bubbles already working elswhere
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            animator.TryPlayAnimation("Victory"); // "roars, ground shatters"
            Invoke("Attack_Ice_Spikes", 2.5f);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            animator.TryPlayAnimation("Attack01");
            Invoke("Attack_Ice_Toss", 1.5f);
        }
    }

    void Attack_Ice_Spikes()
    {
        int side = Random.Range(0, 2);

        if(side == 0) // left side will be spiked
        {
            iceSpikesLeft.SetActive(true);
            Invoke("UnsetLeftSpikes", 10f);
        }

        else if(side == 1) // right
        {
            iceSpikesRight.SetActive(true);
            Invoke("UnsetRightSpikes", 10f);
        }
    }

    void UnsetLeftSpikes()
    {
        iceSpikesLeft.SetActive(false);
    }

    void UnsetRightSpikes()
    {
        iceSpikesRight.SetActive(false);
    }

    void Attack_Ice_Toss()
    {
        Vector2 spawnPos = new Vector2(30, 3);
        Vector2 playerPos = new Vector2(PlayerGO.transform.position.x, PlayerGO.transform.position.y);

        var snowball = Instantiate(snowballPrefab, spawnPos, Quaternion.identity);

        snowball.transform.position = Vector2.MoveTowards(spawnPos, playerPos, 4f * Time.deltaTime);
    }
}
