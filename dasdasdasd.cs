using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dasdasdasd : MonoBehaviour
{
    AudioSource xzcxzcczx;
    bool asdsad=false;
    bool asdasdasd = false;
    public GameObject asdadasdas;
    // Start is called before the first frame update
    void Start()
    {
        xzcxzcczx = GetComponent<AudioSource>();
    }
    void zxcxzc()
    {
        asdsad = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (asdsad)
        {
            Vector2 dzxir;
            if (transform.position.y < 2)
                dzxir = Vector2.up*0.25f;
            else
            {
                dzxir = Vector2.left;
                asdasdasd = true;
            }
            transform.Translate(dzxir * Time.deltaTime * 3);
        }
    }
    void xzcxzcxzc()
    {
        if (asdasdasd)
        {
            asdadasdas.SetActive(true);
            xzcxzcczx.Play();
        }
    }
}
