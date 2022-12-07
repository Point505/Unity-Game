using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
   
   void Start()
    {
        transform.GetChild(GameManager.level - 1).gameObject.SetActive(true);
    }
}
