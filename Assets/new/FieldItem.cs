using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { Debug.Log("Ãæµ¹"); DestroyItem(); }
    }
    /*public Item item;
    public MeshRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

 
    }

    public Item GetItem()
    {
        return item;
    }*/

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
