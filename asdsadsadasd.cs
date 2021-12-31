using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdsadsadasd : MonoBehaviour
{
    AudioSource asdasdzxcc;
    private void Start()
    {
        asdasdzxcc = GetComponent<AudioSource>();
    }
    void sadadasdasds()
    {
        asdasdzxcc.Play();
    }
    private void OnCollisionStay2D(Collision2D asdasd)
    {
        foreach (var d in asdasd.contacts)
        {
            vxcxcxcv zxcxzcc = d.collider.GetComponent<vxcxcxcv>();
            if (zxcxzcc)
                zxcxzcc.asdasdad(d.point);
            else
            {
                Player asdasda = d.collider.GetComponent<Player>();
                if (asdasda) asdasda.TakeDamage(3);
            }
        }
    }
}
