using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuS : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        ObjectPoolingManager.Instance.ResetPool();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameIsPaused = false;
    }

    public void Back()
    {
        Time.timeScale = 1f;
        ObjectPoolingManager.Instance.ResetPool();
        SceneManager.LoadScene("MainMenu");
        gameIsPaused = false;

    }
}
