using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlevel : MonoBehaviour
{
    AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (SceneManager.GetActiveScene().name.Substring(5))
            {
                case "1":
                    other.gameObject.transform.position = new Vector2(-8.2f, -1.9f);
                    break;
                case "3":
                    other.gameObject.transform.position = new Vector2(-8.2f, 0f);
                    other.gameObject.GetComponent<Player>().stageasdasda = true;
                    break;
                default:
                    other.gameObject.transform.position = new Vector2(-8.2f, 0f);
                    break;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
