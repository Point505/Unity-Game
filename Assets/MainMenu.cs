using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    



    public GameObject MainCanvas;
    public GameObject GameStartCanvas;
    public GameObject countdownUI;
    public GameObject IngameUI;
    public GameObject EndUI;
  

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
        MainCanvas.gameObject.SetActive(false);
        GameStartCanvas.gameObject.SetActive(true);
        countdownUI.gameObject.SetActive(false);
        IngameUI.gameObject.SetActive(false);
    }
    public void OnClickLoad()
    {
        Debug.Log("창닫기");
        MainCanvas.gameObject.SetActive(false);
        IngameUI.gameObject.SetActive(true);
    }
    public void OnClickMap()
    {
        Debug.Log("맵");
    }
    public void OnClickCustom()
    {
        Debug.Log("코스툼");
    }
    public void OnClickOption()
    {
        Debug.Log("옵션");
    }
    public void OnClickRank()
    {
        Debug.Log("순위표");
        
}
    public void OnClickText()
    {
        Debug.Log("설명");
    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
   

    public void OnClickReGame()
    {
        Debug.Log("다시게임시작");
        MainCanvas.gameObject.SetActive(true);
        EndUI.gameObject.SetActive(false);

    }
}
