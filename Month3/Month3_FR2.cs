using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month3_FR2 : EnemyBullet
{    
    void Start ()
    {
        StartCoroutine(DestroySelf_());
    }

    IEnumerator DestroySelf_()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
