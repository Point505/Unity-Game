using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isLive;
    public static int score;
    public static int health = 3;
    public static int level=1;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    public static void GameStart()
    {
        isLive = true;
        Next();

    }
    public static void GameOver()
    {
        SceneManager.LoadScene("End");

    }
    public static void GameFail()
    {
        SceneManager.LoadScene("Fail");

    }



    public static void GetItem()
    {
        score += 100;
    }

    public static void Next()
    {
        level += 1;
        
        if (level < 3)
        {
            SceneManager.LoadScene("SampleScene2");
        }
        else
        {
            int highScore = PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", Mathf.Max(highScore,score)); 
            SceneManager.LoadScene("End");
        }
    }
}
