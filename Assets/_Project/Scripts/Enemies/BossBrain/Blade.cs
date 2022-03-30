using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Transform[] point;

    public float speed;

    public Vector3 targetPosition;

    public int index;

    private void Initialization()
    {
        targetPosition = point[index].position;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //if (transform.position == targetPosition)
        //{
        //    index++;
        //    if (index >= point.Length)
        //    {
        //        index = 0;
        //    }
        //    targetPosition = point[index].position;
        //}

        for(int i = 0; i < point.Length; i++)
        {
            if (transform.position == point[i].position)
            {
                index = (i + 1) % point.Length;
                targetPosition = point[index].position;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.Rotate(0, 0, -300 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
