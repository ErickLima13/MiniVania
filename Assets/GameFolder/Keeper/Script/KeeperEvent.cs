using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip attackSound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keeperAttackSound()
    {
        audioSource.PlayOneShot(attackSound, 0.5f);
    }
}
