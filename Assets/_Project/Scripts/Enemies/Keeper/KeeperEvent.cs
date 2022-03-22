using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip attackSound;

    private void Initialization()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    public void keeperAttackSound()
    {
        audioSource.PlayOneShot(attackSound, 0.5f);
    }
}
