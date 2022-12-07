using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitTime : MonoBehaviour
{

    public Text timerTxt;
    // Start is called before the first frame update
    void Start()
    {
        timerTxt.text = Mathf.Floor(Timer.timer.selectCountdown).ToString();

    }





}
