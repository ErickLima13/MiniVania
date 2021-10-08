using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;
    public GameObject player;

    public Text heartCounText;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        BossBrain();

        if (transform.CompareTag("Player"))
        {
            heartCounText.text = "x" + life.ToString();
        }

    }

    public void Die()
    {
        if (life <= 0 && !transform.name.Equals("BossBrain"))
        {
            skin.GetComponent<Animator>().Play("Die", -1);
        }
    }

    public void PlayerDamage(int value)
    {
        life -= value;
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("ShakeCamera", -1);
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().clips[3], 0.4f);
        
    }

    public void BossBrain()
    {
        if (transform.name.Equals("BossBrain"))
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f, (life * 1.09f / 30f));

            if(life <= 0)
            {

                GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
                GameObject.Find("Player").GetComponent<CapsuleCollider2D>().enabled = false;
                GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                

            }
        }
    }

}
