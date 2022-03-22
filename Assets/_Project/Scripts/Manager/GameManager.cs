using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject player;

    private void Update()
    {
        PauseGame();
        Death();
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
            AudioListener.pause = true;
        }
    }

    public void DestroyPlayer()
    {
        Destroy(player);
        AudioListener.pause = false;
    }
}
