using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class Slot : MonoBehaviour
{
   
    public Stack<Mission> slot;       // 슬롯을 스택으로 만든다.
    private Image MissionImg;
    private bool isSlot;     // 현재 슬롯이 비어있는지?

    public Mission MissionReturn() { return slot.Peek(); } // 슬롯에 존재하는 아이템이 뭔지 반환.
    public bool isSlots() { return isSlot; } // 슬롯이 현재 비어있는지? 에 대한 플래그 반환.
    public void SetSlots(bool isSlot) { this.isSlot = isSlot; }

    void Start()
    {
        // 스택 메모리 할당.
        slot = new Stack<Mission>();
        
        // 맨 처음엔 슬롯이 비어있다.
        isSlot = false;
        MissionImg = transform.Find("Mission").GetComponent<Image>();
    }

    public void AddMission(Mission mission)
    {
        // 스택에 아이템 추가.
        slot.Push(mission);
        UpdateInfo(true, mission.DefaultImg);
    }

    // 슬롯에 대한 각종 정보 업데이트.
    public void UpdateInfo(bool isSlot, Sprite sprite)
    {
        SetSlots(isSlot);                                          // 슬롯이 비어있다면 false 아니면 true 셋팅.
        MissionImg.sprite = sprite;                                   // 슬롯안에 들어있는 아이템의 이미지를 셋팅.
        //MissionIO.SaveDate();                                         // 인벤토리에 변동사항이 생겼으므로 저장.
    }
}
