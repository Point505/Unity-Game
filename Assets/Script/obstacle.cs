using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public enum ObstacleType { milk };
    public ObstacleType obstacletype;
    public int value;

    void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }
}



