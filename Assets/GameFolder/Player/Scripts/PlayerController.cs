using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    public AudioSource audioSource;

    [Header("audioClips")]
    public AudioClip[] clips;


    public Transform floorCollider;
    public Transform skin;
    public Transform gameOverScreen;
    public Transform pauseScreen;

    [Header("Atributtes")]
    public int comboNum;
    public float comboTime;
    public float dashTime;
    public float jumpForce;
    public float dashForce;
    public float speed;
    public string currentLevel;
    

    public LayerMask floorLayer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        currentLevel = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(transform.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        Walk();
        Jump();
        Dash();
        AttackCombo();
        PauseGame();
        Portal();

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
        // faz o player pular
        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.1f, floorLayer);
        if (canJump && Input.GetButtonDown("Jump"))
        {
            audioSource.PlayOneShot(clips[2], 0.5f);
            rb.velocity = Vector2.zero;
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.AddForce(new Vector2(0, jumpForce));

        }
    }

    public void AttackCombo()
    {
        comboTime = comboTime + Time.deltaTime;

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
            Invoke("RestoreGravityScale", 0.5f);
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


    public void PauseGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }
    }
    public void DestroyPlayer()
    {
        Destroy(transform.gameObject);
    }

    public void Death()
    {
        if (GetComponent<Character>().life <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            rb.simulated = false;
            this.enabled = false;
        }
    }

    void RestoreGravityScale()
    {
        rb.gravityScale = 6;
    }
}
