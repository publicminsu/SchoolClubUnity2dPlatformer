using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject[] UIhealth;
    private Heart[] hearts;
    public PlayerMove plymove;
    private static GameManager _instance;
   
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
        plymove = FindObjectOfType<PlayerMove>();
        hearts = new Heart[UIhealth.Length];
        for (int i = 0; i < UIhealth.Length; i++)
            hearts[i] = UIhealth[i].GetComponent<Heart>();

        
    }
    public void HpUpdate()
    {
        for (int i = 0; i < player.hp; i++)
        {
            hearts[i].Up();
        }
        for (int i = player.hp; i < 3; i++)
        {
            hearts[i].Down();
        }
    }
    
    public void NotMove()
    {
        plymove.notMove = true;
    }
    public void Move()
    {
        plymove.notMove = false;
    }
}
