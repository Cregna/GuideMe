using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject ScoreUI;
    [SerializeField] private Text Time;
    [SerializeField] private Text Score;
    [SerializeField] private Text Highscore;
    public Transform next_road_position;
    [SerializeField] private GameObject straight;
    [SerializeField] private GameObject right45;
    [SerializeField] private GameObject right90;
    [SerializeField] private GameObject left45;
    [SerializeField] private GameObject left90;
    [SerializeField] private GameObject plane;

    private bool first;

    private void Awake()
    {
        first = false;
        ObjectPoolingManager.Instance.CreatePool(straight, 15, 20);
        ObjectPoolingManager.Instance.CreatePool(right45, 15, 20);
        ObjectPoolingManager.Instance.CreatePool(right90, 15, 20);
        ObjectPoolingManager.Instance.CreatePool(left45, 15, 20);
        ObjectPoolingManager.Instance.CreatePool(left90, 15, 20);
        ObjectPoolingManager.Instance.CreatePool(plane, 3000, 5300);

    }
    //    ObjectPoolingManager.Instance.CreatePool(m_bullet, 50, 50);
    //ObjectPoolingManager.Instance.CreatePool(m_grunt, 50, 50);
    //ObjectPoolingManager.Instance.CreatePool(m_grunt_explosion, 50, 50);
    //ObjectPoolingManager.Instance.CreatePool(m_hulk, 50, 50);
    // Update is called once per frame
    private void Start()
    {
      
    }
    void Update()
    {

    }

    public void Pause()
    {
        
    }

    public void EndGameOnline()
    {
        string split = "TIME: ";
        if (!first)
        {
            ScoreUI.SetActive(false);
            string score = Time.text.Substring(Time.text.IndexOf(split) + split.Length);
            Score.text = "Time alive: " + score;
            first = true;

            if (PlayerPrefs.HasKey("HighscoreOnline"))
            {
                Highscore.text = "Best time alive: " + PlayerPrefs.GetString("HighscoreOnline");
                TimeSpan thigh = TimeSpan.Parse(PlayerPrefs.GetString("HighscoreOnline"));
                TimeSpan tscore = TimeSpan.Parse(score);
                if (thigh.Subtract(tscore) < TimeSpan.Zero)
                {
                    PlayerPrefs.SetString("HighscoreOnline", score);
                }

            }
            else
            {
                Highscore.text = "Best time alive: No score yet";
                PlayerPrefs.SetString("HighscoreOnline", score);
            }




        }
        //Time.timeScale = 0;
        GameOverUI.SetActive(true);
        ObjectPoolingManager.Instance.ResetPool();
        Debug.Log("GAME OVER");
    }
    public void EndGame()
    {
        ScoreUI.SetActive(false);
        Debug.Log(Diffulty.Difficulty);
        string prefhigh = String.Concat("Highscore",Diffulty.Difficulty);
        string split = "TIME: ";
        if (!first)
        {
             string score = Time.text.Substring(Time.text.IndexOf(split) + split.Length);
             Score.text = "Time alive: " + score;
             first = true;

             if (PlayerPrefs.HasKey(prefhigh))
             {
                 Highscore.text = "Best time alive: " + PlayerPrefs.GetString(prefhigh);
                 TimeSpan thigh = TimeSpan.Parse(PlayerPrefs.GetString(prefhigh));
                 TimeSpan tscore = TimeSpan.Parse(score);
                 if (thigh.Subtract(tscore) < TimeSpan.Zero)
                 {
                     PlayerPrefs.SetString(prefhigh, score);
                 }

             }
             else
             {
                 Highscore.text = "Best time alive: No score yet";
                 PlayerPrefs.SetString(prefhigh, score);
             }




        }
        //Time.timeScale = 0;
        GameOverUI.SetActive(true);
        ObjectPoolingManager.Instance.ResetPool();
        Debug.Log("GAME OVER");
    }

    public void RestartGame()
    {
        ObjectPoolingManager.Instance.ResetPool();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1;

    }

    public void spaceKey() {
    
        //Sroad.transform.position = vector3;
    }
}
