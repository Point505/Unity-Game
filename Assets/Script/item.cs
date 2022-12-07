using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class item : MonoBehaviour
{
    public enum ItemType {cupcake, cookie };
    public ItemType itemtype;
    public int value;

    void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }
}
