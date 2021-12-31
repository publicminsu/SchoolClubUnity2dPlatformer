using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;




public class Keyinfo : MonoBehaviour
{
    struct Keycheck
    {
        public int key_R;
        public int key_Z;
        public int key_Space;
        public int key_UpArrow;
        public int key_DownArrow;
        public int key_LeftArrow;
        public int key_RightArrow;

        public int cheak()
        {
            return this.key_R + this.key_Z + this.key_Space + this.key_UpArrow + this.key_DownArrow + this.key_LeftArrow + this.key_RightArrow;
        }
    }

    Keycheck keycheck;


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            keycheck.key_R = 1;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            keycheck.key_Z = 1;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            keycheck.key_Space = 1;
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            keycheck.key_UpArrow = 1;
            transform.GetChild(3).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            keycheck.key_DownArrow = 1;
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            keycheck.key_LeftArrow = 1;
            transform.GetChild(5).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            keycheck.key_RightArrow = 1;
            transform.GetChild(6).GetComponent<TextMeshProUGUI>().color = Color.gray;
        }

        if (keycheck.cheak() == 7)
        {
            SceneManager.LoadScene("month1");
        }
    }
}