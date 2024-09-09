using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    //public float airJumpForce;   //weak force jump in the air
    public int maxJumps;
    public int jumpCount;

    public Animator animator;
    public Rigidbody2D rb2D;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public bool grounded;

    public Image filler;  //This is the image.We'll adjust fillamount value.

    

    public float counter; // This runs from 0 -> maxCounter in seconds and start again from 0.
    public float maxCounter;





    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);

        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxisRaw("Horizontal") != 0)

        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk", true);

        }
        else
        {
            animator.SetBool("Walk", false);
        }


        if (Input.GetButtonDown("Jump") && (grounded || jumpCount < 1)) {

            rb2D.velocity = new Vector2(0, jumpForce);
            animator.SetTrigger("Jump");

            if (grounded)
            {
                
                jumpCount = 0;
            }
            else
            {
                jumpCount++;
            }

            if (grounded)
            {
                jumpCount = 0;
            }
        }


        //Health bar stuff
        if (counter > maxCounter)
        {   GameManager.manager.previousHealth = GameManager.manager.health;
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }

        filler.fillAmount = Mathf.Lerp(GameManager.manager.previousHealth / GameManager.manager.maxHealth, GameManager.manager.health / GameManager.manager.maxHealth,counter / maxCounter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelEnd"))
        {
            SceneManager.LoadScene("Map");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(15);
          
        }
    }

    public void TakeDamage(float damage)
    {
        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health -= damage;
    }

}
