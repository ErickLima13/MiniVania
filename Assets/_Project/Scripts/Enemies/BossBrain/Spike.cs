using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Transform boss;

    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            boss = collision.transform;
            boss.GetComponent<BossController>().enabled = false;
            collision.transform.parent = transform;
            collision.transform.localPosition = Vector3.zero;
        }
    }

    public void ReleaseBoss()
    {
        if(boss != null)
        {
            boss.GetComponent<BossController>().enabled = true;
            boss.parent = null;
        }
    }

    public void CollisionSound()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
