using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject player;

    public float attackTime;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 5;
            this.enabled = false;
        }

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
            attackTime = attackTime + Time.deltaTime;
            if(attackTime >= 0.6f)
            {
                player.GetComponent<Character>().PlayerDamage(1);
                attackTime = 0;
            }
        }

    }

   

}
