using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public Transform[] point;
    public float speed;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = point[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == (point[0].position))
        {
            targetPosition = point[1].position;
        }

        if (transform.position == (point[1].position))
        {
            targetPosition = point[2].position;
        }

        if (transform.position == (point[2].position))
        {
            targetPosition = point[3].position;
        }

        if (transform.position == (point[3].position))
        {
            targetPosition = point[0].position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        transform.Rotate(0, 0, -2000 * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);


        }
    }
}
