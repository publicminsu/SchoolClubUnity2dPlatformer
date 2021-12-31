using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BNTtype : MonoBehaviour
{
    public BTNtype currentType;
    public void OnButtneClick()
    {
        switch (currentType)
        {
            case BTNtype.Start:
                SceneManager.LoadScene("KeyInfo");
                break;
        }
    }

}
