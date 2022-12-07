using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class MissionUI : NetworkBehaviour
{
    public static MissionUI mission;

    [SyncVar]
    public int index;
    [SyncVar]
    public int index2;

    [SyncVar]
    public int index3;

    [SyncVar]
    public int index4;

    [SyncVar]
    public int index5;

    [SyncVar]
    public int randomindex5;
    [SyncVar]
    public int randomindex4;
    [SyncVar]
    public int randomindex3;
    [SyncVar]
    public int randomindex2;
    [SyncVar]
    public int randomindex;

    public Sprite[] sprites;
    public Text text_index;
    public Text text_name;
    public Text text_index2;
    public Text text_name2;
    public Text text_index3;
    public Text text_name3;
    public Text text_index4;
    public Text text_name4;
    public Text text_index5;
    public Text text_name5;

    public Image image;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Button button_random;



    public string[] MissionList = new string[5];



    void Start()
    {



        index = 1;
        index2 = 2;
        index3 = 1;
        index4 = 2;
        index5 = 1;

        randomindex = Random.Range(0, 25);
        randomindex2 = Random.Range(0, 25);
        randomindex3 = Random.Range(0, 25);
        randomindex4 = Random.Range(0, 25);
        randomindex5 = Random.Range(0, 25);

        Console.Write(MissionList);

        //Init_UI();
        // Funciton_RandomImage();
        //3초뒤 미션UI 사라짐
        // CmdFunciton_RandomImage();

        //Invoke("OffMissionUI", 3f);
        //  Funciton_RandomImage();
    }
    private void Update()
    {
        //CmdFunciton_RandomImage();
        // Funciton_RandomImage();
        RpcFunciton_RandomImage(randomindex, randomindex2, randomindex3, randomindex4, randomindex5);
        Funciton_RandomImage(index, index2, index3, index4, index5);
        Invoke("OffMissionUI", 3f);

        Console.Write(MissionList);
    }

    public void Awake()
    {
        // CmdFunciton_RandomImage();
    }
    void OffMissionUI()
    {
        gameObject.SetActive(false);
    }

    /* private void Init_UI()
     {
         button_random.onClick.RemoveAllListeners();
         // button_random.onClick.AddListener(Funciton_RandomImage);

     }*/
    [ClientRpc]
    public void RpcFunciton_RandomImage(int randomindex, int randomindex2, int randomindex3, int randomindex4, int randomindex5)
    {

        index = randomindex;


        index2 = randomindex2;


        index3 = randomindex3;


        index4 = randomindex4;


        index5 = randomindex5;




    }
















    public void Funciton_RandomImage(int index, int index2, int index3, int index4, int index5)
    {


        // int index = missionindex;
        Sprite select = sprites[index];
        image.sprite = select;


        // int index2 = missionindex;
        select = sprites[index2];
        image2.sprite = select;


        //int index3 = missionindex;
        select = sprites[index3];
        image3.sprite = select;


        //int index4 = missionindex;
        select = sprites[index4];
        image4.sprite = select;


        //int index5 = missionindex;
        select = sprites[index5];
        image5.sprite = select;


        text_index.text = index.ToString();
        text_name.text = sprites[index].name;

        text_index2.text = index2.ToString();
        text_name2.text = sprites[index2].name;

        text_index3.text = index3.ToString();
        text_name3.text = sprites[index3].name;

        text_index4.text = index4.ToString();
        text_name4.text = sprites[index4].name;

        text_index5.text = index5.ToString();
        text_name5.text = sprites[index5].name;


        Debug.LogFormat("index : {0}, image name : {1}", index, sprites[index].name);



        MissionList[0] = sprites[index].name;
        MissionList[1] = sprites[index2].name;
        MissionList[2] = sprites[index3].name;
        MissionList[3] = sprites[index4].name;
        MissionList[4] = sprites[index5].name;

        Console.Write(MissionList);
    }
}