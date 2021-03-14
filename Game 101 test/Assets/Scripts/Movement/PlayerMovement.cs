using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController2D controller;

    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private int extraJumpValue = 10;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private float moveInput;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public GameObject Spellbook;
    [SerializeField]
    private float checkRadius;
    [SerializeField] private bool isGrounded;

    private bool jumpRequest = false;

    Rigidbody2D rb;
    

    [SerializeField]
    [Range(1, 10)]
    private float jumpVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        extraJumps = extraJumpValue;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        FlipOnMouse();
        HorizontalMovement();
        Jumping();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Camera.main.WorldToScreenPoint(Input.mousePosition));
        JumpRequest();
    }


    private void HorizontalMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * horizontalSpeed, rb.velocity.y);
    }

    private void JumpRequest()
    {

            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
            {
                jumpRequest = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
            {
                jumpRequest = true;
            }

            if (isGrounded == true)
                extraJumps = extraJumpValue;
    }

    private void Jumping()
    {
        if (jumpRequest)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            extraJumps--;
            jumpRequest = false;
        }
    }

    private void FlipOnMouse()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameObject.transform.position.x < 0 && facingRight)
            Flip();
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - gameObject.transform.position.x > 0 && !facingRight)
            Flip();
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        Spellbook.GetComponent<BookHandler>().Flip();
    }
    
}
