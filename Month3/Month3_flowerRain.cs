using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month3_flowerRain : MonoBehaviour
{
    Transform playerTf;
    Vector3 flowerRainRange;
    Vector3 flowerRainRange2;
    Vector3 flowerRainRange3;
    public float rainspeed = 0.5f;
    public float rainspeed2 = 0.35f;
    public float rainspeed3 = 0.25f;
    
    public GameObject flowerPrefab;

    void Start()
    {
        // playerTf = GameObject.Find ("Player").transform;
        StartCoroutine("flowerrain");
        StartCoroutine("flowerrain2");
        StartCoroutine("flowerrain3");
    }

    // 한개의 코루틴에서 생성하지 않는 이유는 각 지역의 길이가 달라서 스폰 시간의 차이가 필요하기 때문
    IEnumerator flowerrain() {
        while(true) {
            Instantiate(flowerPrefab, flowerRainRange, transform.rotation);
            yield return new WaitForSeconds(rainspeed);
        }
    }
    IEnumerator flowerrain2() {
        while(true) {
            Instantiate(flowerPrefab, flowerRainRange2, transform.rotation);
            yield return new WaitForSeconds(rainspeed2);
        }
    }
    IEnumerator flowerrain3() {
        while(true) {
            Instantiate(flowerPrefab, flowerRainRange3, transform.rotation);
            yield return new WaitForSeconds(rainspeed3);
        }
    }

    void Update()
    {
        // int flowerR = (int)playerTf.position.x-10;
        // int flowerL = (int)playerTf.position.x+10;
        
        // int RanSpwan = Random.Range(flowerL, flowerR);
        // flowerRainRange = new Vector3(RanSpwan, (int)playerTf.position.y+5, 0);

        float RanSpwan = Random.Range(49, 56);
        flowerRainRange = new Vector3(RanSpwan, 4, 0);

        float RanSpwan2 = Random.Range(87, 105);
        if (RanSpwan2 < 88) {
            flowerRainRange2 = new Vector3(RanSpwan2, 7, 0);    
        } else if (RanSpwan2 < 89) {
            flowerRainRange2 = new Vector3(RanSpwan2, 4, 0);    
        } else if (RanSpwan2 < 90) {
            flowerRainRange2 = new Vector3(RanSpwan2, 3, 0);    
        } else if (RanSpwan2 < 91) {
            flowerRainRange2 = new Vector3(RanSpwan2, 2, 0);    
        } else {
            flowerRainRange2 = new Vector3(RanSpwan2, 1, 0);    
        }

        float RanSpwan3 = Random.Range(127, 150);
        flowerRainRange3 = new Vector3(RanSpwan3, 13, 0);
    }
}
