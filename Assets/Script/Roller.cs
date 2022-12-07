using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    public float speed;

    void Update()
    {
        //20프레임은 20번
        //60프레임은 60번

        transform.Rotate(0, speed * Time.deltaTime, 0,Space.World);
    }
}
