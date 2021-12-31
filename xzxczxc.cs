using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xzxczxc : MonoBehaviour
{
    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D asdasd)
    {
        PlayerMove asdad = asdasd.gameObject.GetComponent<PlayerMove>();
        if (asdad)
        {
            asdad.auasdasd();
            asdad.bulletstate = true;
            Destroy(this.gameObject);
        }
    }
}
