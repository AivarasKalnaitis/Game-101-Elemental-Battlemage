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
    private Animator anim;
    private bool jumpRequest = false;

    private Rigidbody2D rb;
    [SerializeField] private AnyStateAnimator animator;
    [SerializeField] private PlayerComponents components;

    [SerializeField]
    [Range(1, 10)]
    private float jumpVelocity;

    private bool onIce = false;


    public PlayerComponents Components
    {

        get { return components; }
    }

    public AnyStateAnimator Animator
    {
        get { return animator; }
    }
    private void Awake()
    {
        anim = new Animator();
        anim = gameObject.GetComponent<Animator>();
        //  components = new PlayerComponents();
        //animator = GetComponent<AnyStateAnimator>();
    }

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
            
        extraJumps = extraJumpValue;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Body_Idle"),

            new AnyStateAnimation(RIG.LEGS, "Legs_Idle"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk"),

            new AnyStateAnimation(RIG.ARMS, "Arms_Idle"),
            new AnyStateAnimation(RIG.ARMS, "Arms_Walk"),


        };

        animator.AddAnimations(animations);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ice")
        {
            onIce = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        FlipOnMouse();
        HorizontalMovement();
        Jumping();
    }

    void Update()
    {
        JumpRequest();
    }


    private void HorizontalMovement()
    {
        moveInput = Input.GetAxis("Horizontal");

        if(onIce)
        {
            rb.AddForce(new Vector2(moveInput * horizontalSpeed*3f, rb.velocity.y));
            onIce = false;
        }

        else
        {
            rb.velocity = new Vector2(moveInput * horizontalSpeed, rb.velocity.y);

            if (moveInput != 0)
            {
                animator.TryPlayAnimation("Legs_Walk");
                animator.TryPlayAnimation("Arms_Walk");
                animator.TryPlayAnimation("Body_Idle");
            }
            else if (moveInput == 0)
            {
                animator.TryPlayAnimation("Legs_Idle");
                animator.TryPlayAnimation("Arms_Idle");
                animator.TryPlayAnimation("Body_Idle");
            }
        }
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
