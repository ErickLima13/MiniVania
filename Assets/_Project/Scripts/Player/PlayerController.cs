using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vel;

    private float comboTime;
    private float dashTime;

    private bool isGrounded;

    private string currentLevel;

    public int comboNum;

    public float jumpForce;
    public float dashForce;
    public float speed;
    public float distance;

    public AudioSource audioSource;

    public AudioClip[] clips;

    public Transform skin;
    public Transform gameOverScreen;

    public LayerMask tileMapFront;

    private void Initialization()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        AttackCombo();
        Portal();
        Jump();
        Walk();
        PhysicsCheck();
    }

    private void FixedUpdate()
    {
        if(dashTime > 0.5)
        {
            rb.velocity = vel ;
        }
    }

    public void Walk()
    {
        // faz o player andar pra esquerda e direita
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        //controla as animações de andar do player
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                audioSource.PlayOneShot(clips[2], 0.5f);
                skin.GetComponent<Animator>().Play("PlayerJump", -1);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void PhysicsCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, distance, tileMapFront);
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
    }

    public void AttackCombo()
    {
        comboTime += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && comboTime > 0.5f)
        {
            comboNum++;
            if(comboNum > 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);

            if(comboNum == 1)
            {
                audioSource.PlayOneShot(clips[0], 0.5f);
            }

            if (comboNum == 2)
            {
                audioSource.PlayOneShot(clips[1], 0.5f);
            }
        }

        if (comboTime >= 1)
        {
            comboNum = 0;
        }
    }
    
    public void Dash()
    {
        dashTime += Time.deltaTime;

        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            audioSource.PlayOneShot(clips[4],0.5f);
            dashTime = 0;
            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            rb.AddForce(new Vector2( skin.localScale.x * dashForce, 0));
            Invoke(nameof(RestoreGravityScale), 0.5f);
        }
    }

    public void Portal()
    {
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        }
    }

    private void RestoreGravityScale()
    {
        rb.gravityScale = 6;
    }
}
