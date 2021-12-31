using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ddasd : MonoBehaviour
{
    public void dasd()
    {
        SceneManager.LoadScene(1);
    }
    public void sadasd()
    {
        GameObject asdad = GameObject.Find("Main Camera");
        SceneManager.sceneLoaded -= asdad.GetComponent<Move_Camera>().SceneLoading;
        Destroy(asdad);
        Destroy(GameObject.Find("Game Manager"));
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("UI"));
        SceneManager.LoadScene(0);
    }
}
