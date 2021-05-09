using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool isGrounded;
    [SerializeField] private float checkRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public Rigidbody2D rb;
    public float movementSpeed = 10;
    public float jumpVelocity = 10f;
    public short jumpCount;
    public short jumpCountMax = 2;
    public float lerpSpeed = 5f;
    public float axis;
    public bool jumpPress;
    public GameObject PlayerGO;
    public float fireForce = 20f;
    public bool fire;
    //public bool jumpPress;
    void Start()
    {
        jumpCount = jumpCountMax;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(axis * movementSpeed, rb.velocity.y),
            Time.deltaTime * lerpSpeed);
        if (fire)
        {
            FireYourself();
            fire = false;
        }

        //HorizontalMov(axis);
        if (jumpPress && jumpCount > 0)
        {

            PressJump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            jumpCount = jumpCountMax;
        }
    }
    public void HorizontalMov(float _axis)
    {
        rb.velocity = new Vector2(_axis * movementSpeed, rb.velocity.y);
    }

    public void FireYourself()
    {
        float multiplier = fireForce / (Mathf.Abs(PlayerGO.transform.position.x - transform.position.x) +
                                        Mathf.Abs(PlayerGO.transform.position.y - transform.position.y));

        Vector2 playerDirection = new Vector2((PlayerGO.transform.position.x - transform.position.x) * multiplier * fireForce, (PlayerGO.transform.position.y - transform.position.y) * multiplier * fireForce * 3);
        rb.AddForce(playerDirection);
        //rb.AddForce(Vector2.up * fireForceVertical, ForceMode2D.Impulse);
        //rb.AddForce(playerDirection * fireForce, ForceMode2D.Impulse);
    }

    public void FireAway(float loadTime)
    {
        Invoke("FireTruth", 1.5f);
    }

    private void FireTruth()
    {
        fire = true;
    }
    public void PressJump()
    {

        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        //rb.velocity = Vector2.up * jumpVelocity;
        jumpCount--;
        jumpPress = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerGO.GetComponent<PlayerStats>().TakeDamage(10);
            Destroy(gameObject);
        }   
    }



}
