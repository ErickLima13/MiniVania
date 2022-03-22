using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject player;

    public float attackTime;
    public float speed;

    private void Initialization()
    {
        attackTime = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        Drain();
    }

    public void Drain()
    {
        if(Vector2.Distance(transform.position,player.GetComponent<CapsuleCollider2D>().bounds.center ) > 0.9f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center, speed * Time.deltaTime);
        }
        else
        {
            attackTime += Time.deltaTime;
            if(attackTime >= 0.6f)
            {
                player.GetComponent<Character>().PlayerDamage(1);
                attackTime = 0;
            }
        }

    }

    public void Death()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 5;
            this.enabled = false;
        }
    }
}
