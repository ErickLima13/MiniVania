using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorController : MonoBehaviour
{
    int lifeChange;

    public Transform lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        lifeChange = GetComponent<Character>().life;
    }

    // Update is called once per frame
    void Update()
    {


        Damage();
        Broke();
        
    }

    public void Damage()
    {
        if (lifeChange != GetComponent<Character>().life)
        {
            lifeChange = GetComponent<Character>().life;
            GetComponent<Character>().skin.GetComponent<Animator>().Play("EnemyDoorDamage", -1);
        }
    }

    public void Broke()
    {
        if(GetComponent<Character>().life <= 0)
        {
            Destroy(transform.gameObject);
        }

        lifeBar.localScale = new Vector3((2 * GetComponent<Character>().life) / 10f, 1, 1);
    }
}
