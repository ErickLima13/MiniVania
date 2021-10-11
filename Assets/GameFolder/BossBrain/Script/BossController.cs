﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    AudioSource audios;

    public Transform[] point;
    public float speed;
    public Transform laser;
    public float laserTime;
    public AudioClip clip;
    public AudioClip clipLaser;


    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {

        audios = GetComponent<AudioSource>();
        targetPosition = point[0].position;
        BossLaugh();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            return;
        }

        Patrol();
        LaserAttack();

       
    }

    public void Patrol()
    {
        if (transform.position == point[0].position)
        {
            targetPosition = point[1].position;
        }

        if (transform.position == point[1].position)
        {
            targetPosition = point[0].position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void LaserAttack()
    {
        laserTime += Time.deltaTime;

        if(laserTime > 6)
        {
            laserTime = 0;
            laser.gameObject.SetActive(false);
            laser.GetChild(0).GetComponent<TrailRenderer>().Clear();
            laser.position = transform.position;
            laser.gameObject.SetActive(true);
            audios.PlayOneShot(clipLaser,0.5f);

        }
    }

    private void BossLaugh()
    {
        Invoke("BossLaugh", 15);
        audios.PlayOneShot(clip,0.5f);
    }
}
