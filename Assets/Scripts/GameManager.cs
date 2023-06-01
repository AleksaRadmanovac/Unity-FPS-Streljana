using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isOver = false;
    private static bool reset;
    // Start is called before the first frame update
    void Start()
    {
        reset = false;
        GameObject gameoverScreen = GameObject.FindWithTag("GameoverScreen");
        gameoverScreen.transform.GetChild(0).gameObject.SetActive(false);
        GameObject pauseScreen = GameObject.FindWithTag("PauseScreen");
        pauseScreen.transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("Startgameoverscreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (IgracMovement.lifes <= 0)
        {
            if (!isOver && !reset)
                GameOver();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Unpause();
                }
                else Pause();
            }
        }
    }

    public static void GameOver()
    {
        Debug.Log("Gameoverprikaz");
        GameObject gameoverScreen = GameObject.FindWithTag("GameoverScreen");
        gameoverScreen.transform.GetChild(0).gameObject.SetActive(true);
        isOver = true;
        Time.timeScale = 0;

    }

    public static void RestartGame()
    {
        reset = true;
        Debug.Log("Restartovano");
        isOver = false;
        isPaused = false;
        TargetScript.startCalled = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Pause() 
    {
        if(!isOver) {
            isPaused = true;
            Time.timeScale = 0;
            GameObject pauseScreen = GameObject.FindWithTag("PauseScreen");
            pauseScreen.transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }

    public static void Unpause()
    {
        if(!isOver)
        {
            isPaused = false;
            Time.timeScale = 1;
            GameObject pauseScreen = GameObject.FindWithTag("PauseScreen");
            pauseScreen.transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }
}
