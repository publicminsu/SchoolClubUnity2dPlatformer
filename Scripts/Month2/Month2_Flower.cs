using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month2_Flower : EnemyBullet
{
    float rotateSpeed = 1000;
    void Start()
    {
        Destroy(this.gameObject,8f);
    }
    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
