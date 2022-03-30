using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform skin;
    public Transform keeperRange;

    public AudioSource audioSource;
    public AudioClip[] clips;

    public float speed;

    public bool goRight;

    // Update is called once per frame
    void Update()
    {
        Patrol();
        Die();
    }

    public void Patrol()
    {
        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }
        
        if (goRight == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, speed * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, speed * Time.deltaTime);
        }
    }

    private void Die()
    {
        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(clips[0]);
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }
    }
    
    public void OnHit()
    {
        skin.GetComponent<Animator>().Play("KeeperHit");
    }
}
