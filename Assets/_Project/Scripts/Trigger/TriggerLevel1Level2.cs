using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel1Level2 : MonoBehaviour
{
    public Animator anim;

    public float transitionDelayTime = 1.0f;

    public int index;

    private void Initialization()
    {
        anim = GameObject.Find("Transition").GetComponent<Animator>();
    }

    private void Awake()
    {
        Initialization();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(index);
            StartCoroutine(DelayLoadLevel());
        }
    }

   IEnumerator DelayLoadLevel()
    {
        anim.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
    }
}
