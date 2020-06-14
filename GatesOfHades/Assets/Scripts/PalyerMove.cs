using GatesOfHades.Shake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public bool hotJumped;
    public Animator anim;
    
    public Transform groundCheck;
    public Transform Wallcheck;

    public AudioSource jumpSound;
    public AudioSource walk;
   
    public float groundCheckRadius;
    public float wallCheckRadius;
    private bool onGround;
    public float jumpForce = 5f;
    public LayerMask whatIsBoat;
    public LayerMask whatIsWater;
    public LayerMask whatIsGround;

    public GameObject waterEffect;
    public GameObject dustEffect;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround =     Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        bool onBoat =  Physics2D.OverlapCircle(groundCheck.position, wallCheckRadius, whatIsBoat);
        bool onWater = Physics2D.OverlapCircle(groundCheck.position, wallCheckRadius, whatIsWater);
        bool onWall =  Physics2D.OverlapCircle(Wallcheck.position, wallCheckRadius, whatIsGround);



        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
       
        
       
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("takeOff");
            Invoke("SpawnDust", 0f);
            jumpSound.Play();

        } else if(Input.GetKeyDown(KeyCode.Space) && onBoat)
        {
                 rb.velocity = new Vector2(rb.velocity.x, jumpForce * 2.5f);
                anim.SetTrigger("takeOff");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && onWater)
        {
                Instantiate(waterEffect, groundCheck.position, Quaternion.identity);
        }




          if (onGround)
        {
    
          anim.SetBool("isJumping", false);
          hotJumped = false;
        
        }
        else
        {
            anim.SetBool("isJumping", true);
            if(hotJumped == false)
            CameraShake.ShakeOnce(1f,3f);
            hotJumped = true;
        }
       
    
        if (Input.GetKeyDown(KeyCode.Space) && onWall)
        {
            Debug.Log("Walled");
            rb.AddForce(new Vector3(jumpForce * 100, jumpForce, 0), ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && onGround)
         {
            anim.SetBool("isWalking", true);
           if(!walk.isPlaying)
            {
                walk.volume = Random.Range(0.5f, 0.8f);
                walk.pitch = Random.Range(0.7f, 1f);
                walk.Play();
            }

        }  else
           {
            anim.SetBool("isWalking", false);
           } 

    
    }

    public void SpawnDust()
    {
       
            Instantiate(dustEffect, groundCheck.position, Quaternion.identity);

    }
}
