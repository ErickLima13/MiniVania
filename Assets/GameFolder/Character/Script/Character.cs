﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;
    public GameObject player;

    public Text heartCounText;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Die();

        heartCounText.text = "x" + life.ToString();
    }

    public void Die()
    {
        if (life <= 0)
        {
            skin.GetComponent<Animator>().Play("Die", -1);
        }
    }

    public void PlayerDamage(int value)
    {

        life -= value;
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("ShakeCamera", -1);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }


}
