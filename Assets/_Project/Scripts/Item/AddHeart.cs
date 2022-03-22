using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    private AudioSource audios;

    public AudioClip clip;

    private void Initialization()
    {
        audios = GetComponent<AudioSource>();
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
            audios.PlayOneShot(clip);
            collision.GetComponent<Character>().life++;
            Destroy(gameObject,0.1f);
        }
    }
}
