using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    private Transform player;

    public Transform spawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            player.GetComponent<Character>().PlayerDamage(1);
            player.GetChild(0).GetComponent<Animator>().Play("PlayerJump", -1);
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        player.GetChild(0).GetComponent<Animator>().Play("PlayerJump", -1);
        yield return new WaitForSeconds(1f);
        player.GetChild(0).GetComponent<Animator>().Play("PlayerJump", -1);
        player.position = spawn.position;
    }
}
