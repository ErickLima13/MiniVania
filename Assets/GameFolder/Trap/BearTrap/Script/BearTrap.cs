using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    Transform player;
    public Transform skin;

    AudioSource audioS;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            audioS.PlayOneShot(clip);

            player = collision.transform;

            skin.GetComponent<Animator>().Play("Stuck", -1);

            player.position = transform.position;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            GetComponent<BoxCollider2D>().enabled = false;

            player.GetComponent<PlayerController>().enabled = false;
            Invoke("ReleasePlayer", 2);
        }
    }

    public void ReleasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
        
    }
}
