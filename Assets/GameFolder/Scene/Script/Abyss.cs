﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    Transform player;
    public Transform spawn;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            player.GetComponent<Character>().life--;
            
            player.GetChild(0).GetComponent<Animator>().Play("PlayerJump", -1);

            player.position = spawn.position;



        }
    }

    
}