using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel1Level2 : MonoBehaviour
{
    public string currentLevel;
    

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(currentLevel == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }

            if(currentLevel == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }



        }
    }
}
