using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    spade
}

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public int extraBullet;


    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
