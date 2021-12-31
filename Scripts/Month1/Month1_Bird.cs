using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month1_Bird : Enemy
{
    int path = 0;
    float speed = 2f;
    public Transform[] tf = new Transform[2];
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, tf[path].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, tf[path].position) == 0)
        {
            path++;
            if (path == 2)
            {
                path = 0;
            }
            sr.flipX = !sr.flipX;
        }
    }
}
