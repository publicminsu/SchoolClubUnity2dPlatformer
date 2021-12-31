using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var obj = FindObjectsOfType<UI>();
        if (obj.Length == 1) { DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
