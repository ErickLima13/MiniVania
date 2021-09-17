using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;

    public Transform floorCollider;
    public Transform skin;

    public int comboNum;
    public float comboTime;

    public LayerMask floorLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackCombo();

        // faz o player pular
        bool canJump = Physics2D.OverlapCircle(floorCollider.position, 0.1f, floorLayer);
        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            skin.GetComponent<Animator>().Play("PlayerJump",-1);
            rb.AddForce(new Vector2(0, 150));

        }

        // faz o player andar pra esquerda e direita
        vel = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);


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

    private void FixedUpdate()
    {
        rb.velocity = vel;
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
        }

        if (comboTime >= 1)
        {
            comboNum = 0;
        }
    }
    
}
