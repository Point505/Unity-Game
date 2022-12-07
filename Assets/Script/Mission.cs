using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Net.NetworkInformation;
//using System.Security.Cryptography;
//using System.Threading;
using UnityEngine;

[System.Serializable]
public class Mission : MonoBehaviour
{
    public static Mission mission;

    public enum MissionType
    {
        cocoa, doughnut, cake, toast, cupcake, cup, display, croissant
    };

    public MissionType missionType;
    public Sprite DefaultImg; 
    public string missionName;
    public int value;
    public Inventory Iv;


    //public bool Use()
    //{
    //    return false;
    //}

    //void Awake()
    //{
    //    // 태그명이 "Inventory"인 객체의 GameObject를 반환한다.
    //    // 반환된 객체가 가지고 있는 스크립트를 GetComponent를 통해 가져온다.
    //    Iv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

    //}

    //void AddItem()
    //{
    //    // 아이템 획득에 실패할 경우.
    //    if (!Iv.AddMission(this)) ;
    //    // Debug.Log("아이템이 가득 찼습니다.");
    //    else // 아이템 획득에 성공할 경우.
    //        gameObject.SetActive(false); // 아이템을 비활성화 시켜준다.
    //}

    //// 충돌체크
    //void OnTriggerEnter(Collider _col)
    //{
    //    // 플레이어와 충돌하면.
    //    if (_col.gameObject.layer == 10)
    //        AddItem();
    //}







    //void Update()
    //{
    //    transform.Rotate(Vector3.up * 15 * Time.deltaTime);
    //}


    //public Mission mission;
    //public SpriteRenderer image;

    //public void SetMission(Mission _mission)
    //{
    //    mission.missionName = _mission.missionName;
    //    mission.missionImage = _mission.missionImage;
    //    mission.missionType = _mission.missionType;

    //    image.sprite = mission.missionImage;

    //}
    //public Mission GetMission()
    //{
    //    return mission;
    //}
    //public void DestroyMission()
    //{
    //    Destroy(gameObject);
    //}
}
