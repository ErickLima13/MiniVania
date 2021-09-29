﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public AudioSource audioSource;
    public AudioClip[] clips;

    public Transform skin;
    public Transform keeperRange;
    public float speed;

    public bool goRight;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();


        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(clips[0], 0.5f);
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            
        }

    }

    public void Patrol()
    {


        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }
        

        if (goRight == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, speed * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, speed * Time.deltaTime);
        }
    }

}
