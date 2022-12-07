using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//트리거 안에 if 문으로 오브젝트가 활성화 되어 있으면 카운트 다운 5초 
// 아니라면 if문에 진입해서 5초간 오브젝트 비 활성화
// 플레이어가 5초뒤 Exit 하면 Count 초기화


public class H1GP : MonoBehaviour
{



    float time = 5.0f;
    int H1g = 0;
    int speed;

   

    // Update is called once per frame
    void Update()
    {
        if (H1g == 1 && time > 0)//지속 시간을 위한 트리거 H=1 time은 5
        {
            time -= Time.deltaTime;
            speed = 3;
        }
        else if (H1g == 1 && time <= 0)// 트리거가 활성화 됬는데 시간이 종료되었다면
        {
            H1g = 0;
            time = 5.0f;
            speed = 15;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "H1g")
        {
            H1g = 1;

        }
       

    }
}
