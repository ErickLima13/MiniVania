using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject player;
    public GameObject bossButton;

    public bool checkpoint;
    public bool isDead;

    private void Update()
    {
        PauseGame();
        Death();
        BossCheckPoint();
    }

    private void PauseGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }
    }

    private void Death()
    {
        if (player.GetComponent<Character>().life <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            player.GetComponent<PlayerController>().enabled = false;
            AudioListener.pause = true;
            isDead = true;
        }
    }

    public void DestroyPlayer()
    {
        Destroy(player);
        AudioListener.pause = false;
    }

    private void BossCheckPoint()
    {
        if(SceneManager.GetActiveScene().name == "Level5" && !checkpoint)
        {
            checkpoint = true;
            bossButton.SetActive(true);
            bossButton = GameObject.Find("BossButton");
        }
    }

    public void BossLevel()
    {
        SceneManager.LoadScene("Level5");
        
    }

    
}
