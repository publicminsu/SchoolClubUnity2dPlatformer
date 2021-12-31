using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Camera: MonoBehaviour
{
    Camera camera;
    public Transform ttarget;
    public float speed;
    float updateY;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        updateY = 1.2f;
        SceneManager.sceneLoaded += SceneLoading;
        var obj = FindObjectsOfType<Move_Camera>();
        if (obj.Length == 1) { DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }
    }

    // Update is called once per frame
    public void SceneLoading(Scene arg0,LoadSceneMode arg1)
    {
        switch (arg0.name.Substring(5))
        {
            case "2":
                camera.backgroundColor = new Color(195 / 255f, 176 / 255f, 189 / 255f);
                updateY = 0;
                break;
            case "3":
                camera.backgroundColor = new Color(195 / 255f, 176 / 255f, 176 / 255f);
                break;
            case "8":
                camera.backgroundColor = new Color(67 / 255f, 56 / 255f, 62 / 255f);
                camera.orthographicSize = 6.7f;
                ttarget = GameObject.Find("asdsad").GetComponent<Transform>();
                break;
            case "11":
                camera.backgroundColor = new Color(60 / 255f, 52 / 255f, 65 / 255f);
                camera.orthographicSize = 9f;
                ttarget = GameObject.Find("Player").GetComponent<Transform>();
                updateY = 2;
                break;
            case "12":
                camera.backgroundColor = new Color(55 / 255f, 55 / 255f, 63 / 255f);
                camera.orthographicSize = 6.77f;
                ttarget = GameObject.Find("asdsad").GetComponent<Transform>();
                break;
        }
    }
    void LateUpdate()
    {
        Vector3 preVec= new Vector3(ttarget.position.x, ttarget.position.y+updateY, -10f);
        transform.position = Vector3.Lerp(transform.position, preVec, Time.deltaTime * speed);
    }
}
