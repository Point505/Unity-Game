using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this
public class ScoreUI : MonoBehaviour
{
    private Inventory iv;
    void update()
    {
        int score, itemscore, timerscore = 0;
        int scorecount = 0;
        float timer = 60; // 총 5분, 300초
        timer = 300 - timer; // 경과시간

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (MissionUI.mission.MissionList[i] == Inventory.iv.missionNameArray[j])
                    scorecount++;
            }
            
        }

        itemscore = scorecount * 100;
        timerscore = (int)timer / 10;
        score = itemscore + timerscore;

        // Debug.Log("score : " + itemscore);
        Debug.Log(MissionUI.mission.MissionList[1]);
        Debug.Log(Inventory.iv.missionNameArray[1]);
    }
    
}