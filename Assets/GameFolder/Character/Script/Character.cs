using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;
    public GameObject player;

    public Text heartCounText;
    public AudioClip bossBattleMusic;
    public AudioClip youWin;


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
        PlayerControll();




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
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


            }
        }
    }

    public void PlayerControll()
    {
        if (transform.CompareTag("Player"))
        {
            heartCounText.text = "x" + life.ToString();

            if (SceneManager.GetActiveScene().name.Equals("Level5"))
            {
                cam.GetComponent<Animator>().enabled = false;
                cam.GetComponent<Camera>().orthographicSize = 10.3f;
                cam.position = new Vector3(1, 2.10f, -1);
                cam.parent = null;
                SceneManager.MoveGameObjectToScene(cam.gameObject, SceneManager.GetActiveScene());

                if(GameObject.Find("BossBrain").GetComponent<Character>().life > 0)
                {
                    if(cam.GetComponent<AudioSource>().clip != bossBattleMusic)
                    {
                        cam.GetComponent<AudioSource>().clip = bossBattleMusic;
                        cam.GetComponent<AudioSource>().Play();
                    }
                }
                else
                {
                    GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                    GetComponent<PlayerController>().enabled = false;
                    GetComponent<CapsuleCollider2D>().enabled = false;
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                    if (cam.GetComponent<AudioSource>().clip != null)
                    {

                        cam.GetComponent<AudioSource>().Stop();
                        cam.GetComponent<AudioSource>().clip = null;
                        cam.GetComponent<AudioSource>().PlayOneShot(youWin);
                    }
                }
                
            }
        }
    }

}
