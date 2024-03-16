using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOverScreenIsActive() && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    bool GameOverScreenIsActive()
    {
        return gameOverScreen.activeSelf;
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
