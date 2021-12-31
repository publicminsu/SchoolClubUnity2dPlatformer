using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawn : MonoBehaviour
{
    public static RainSpawn instance;
    public GameObject rainPrefab;
    public Queue<GameObject> prefabQueue = new Queue<GameObject>();
    public Transform left;
    public Transform right;
    float timer=0;
    public float wt=0.6f;
    void Start()
    {
        instance = this;
        for (int i = 0; i < 10; i++)
        {
            GameObject rainObject = Instantiate(rainPrefab, Vector3.zero, Quaternion.identity);
            prefabQueue.Enqueue(rainObject);
            rainObject.SetActive(false);
        }
    }
    public void InsertQueue(GameObject temp)
    {
        prefabQueue.Enqueue(temp);
        temp.SetActive(false);
    }

    public GameObject GetQueue()
    {
        if(prefabQueue.Count>0)
        {
            GameObject rainObject = prefabQueue.Dequeue();
            rainObject.SetActive(true);
            return rainObject;
        }
        else
        {
            GameObject newObject= Instantiate(rainPrefab, Vector3.zero, Quaternion.identity);
            return newObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > wt)
        {
            GameObject gameObject = GetQueue();
            Vector2 vector2 = new Vector2(Random.Range(left.position.x, right.position.x), Random.Range(left.position.y, right.position.y));
            gameObject.transform.position = vector2;
            timer = 0;
        }
    }
}
