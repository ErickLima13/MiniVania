using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    private Transform player;

    private AudioSource audioS;

    public Transform skin;

    public AudioClip clip;

    private void Initialization()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioS.PlayOneShot(clip);
            player = collision.transform;
            skin.GetComponent<Animator>().Play("Stuck", -1);
            player.GetComponentInChildren<Animator>().Play("PlayerJump");
            player.position = transform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            Invoke(nameof(ReleasePlayer), 2f);
            Invoke(nameof(ResetTrap), 10f);
        }
    }

    public void ReleasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }

    void ResetTrap()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        skin.GetComponent<Animator>().Play("UnStuck", -1);
    }
}
