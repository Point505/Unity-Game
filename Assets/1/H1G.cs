using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//트리거 안에 if 문으로 오브젝트가 활성화 되어 있으면 카운트 다운 5초 
// 아니라면 if문에 진입해서 5초간 오브젝트 비 활성화
// 플레이어가 5초뒤 Exit 하면 Count 초기화


public class H1G : MonoBehaviour
{
    float time = 5.0f;// 벽 생성시간 5초
    int H1gp = 0;// 그라운드 진입 확인
  

    private bool state;

    void Start()
    {
        state = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (state == true && H1gp == 1) // 최초 진입시 벽을 활성화 시키고 
            //재생성을 피하시 위해 H1gp를 0으로 초기화 시킴
        {
            gameObject.SetActive(true);
            H1gp = 0;
        }
        if (state == true && time > 0) // 활성화된 상태에서 0보다 작아지면 탈출
        {
            time -= Time.deltaTime;
        }

        else if (time <= 0) // 0보다 작아지면 비 활성화
        {
            gameObject.SetActive(false);
        }



        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // 플레이어가 H1g 태그 땅을 밞으면 활성화
        {

            state = true;
            H1gp = 1;
        }
       

    }

    void OnTriggerExit(Collider other)// 플레이어가 탈출하면 값을 증가시켜 다시 진입 가능하게
    {
        if (other.tag == "Player")
        {
            H1gp = 1;
            time = 5.0f;
        }


    }
}
