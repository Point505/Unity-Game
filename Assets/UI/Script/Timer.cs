using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static Timer timer;

    public Text timerTxt;
    public float time;
    public float selectCountdown;

    void Start()
    {
        selectCountdown = time;
    }

    void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
        if (timer == null)
        {
            timer = this;
        }

    }
    void Update()
    {
       
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            SceneManager.LoadScene("FailScene");
            
        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }
}
