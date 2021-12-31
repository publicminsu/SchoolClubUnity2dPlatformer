using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    public PlayerSpade Pickspade;
    PlayerMove PM;

    void Start()
    {
        PM = FindObjectOfType<PlayerMove>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();

            if(item.itemType == ItemType.spade)
            {
                Pickspade.bulletCount += item.extraBullet;
                

            }
            Destroy(other.gameObject);
        }
    }
}
