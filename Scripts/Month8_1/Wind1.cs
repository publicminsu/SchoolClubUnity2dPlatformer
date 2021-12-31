using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind1 : MonoBehaviour
{
    public float Speed = -8f;

    private Rigidbody2D WindRigidbody;
    void Start()
    {
        WindRigidbody = GetComponent<Rigidbody2D>();

        WindRigidbody.velocity = transform.right * Speed;

        Destroy(gameObject, 4f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
