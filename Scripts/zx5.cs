using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zx5 : MonoBehaviour
{
    AudioSource Audio;
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Play();
    }
    void asdsadadasd()
    {
        Destroy(this.gameObject);
    }
}
