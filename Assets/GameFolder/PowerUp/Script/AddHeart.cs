using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    AudioSource audios;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audios.PlayOneShot(clip);
            print("toucou");
            collision.GetComponent<Character>().life++;
            Destroy(gameObject,0.2f);
           
        }
    }
}
