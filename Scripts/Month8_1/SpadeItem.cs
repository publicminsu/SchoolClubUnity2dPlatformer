using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeItem : MonoBehaviour
{
    Rigidbody2D SpadeRigidbody;
    void Start()
    {
        SpadeRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player)
        {
            Destroy(gameObject);
            player.SpadeItem();
        }
    }
}
