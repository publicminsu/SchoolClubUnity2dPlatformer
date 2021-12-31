using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month3_sensor : MonoBehaviour
{
    public Month3_flower flower;
    AudioSource Audio;
    Player asdasd;
    void Start()
    {
        asdasd = GameObject.FindObjectOfType<Player>();
        asdasd.Resurrection += resetFlower;
        Audio = GetComponent<AudioSource>();
    }
    void resetFlower()
    {
        if (flower.gameObject.activeSelf)
            return;
        flower.gameObject.SetActive(true);
        flower.gameObject.transform.position = transform.position;
    }
    private void OnDestroy()
    {
        asdasd.Resurrection -= resetFlower;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && flower.gameObject.activeSelf && !flower.isUsed)
        {
            flower.TargetInit(other.transform);
            Audio.Play();
        }
    }
}
