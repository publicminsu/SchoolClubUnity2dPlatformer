using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoenix : MonoBehaviour
{
    public GameObject bullet;

    Transform tr;

    void Start() {
        // transform.position = new Vector3(-30,6,0);
        tr = GetComponent<Transform>();
        StartCoroutine(FireBullet());
    }

    void Update() {
        // transform.Translate(Vector3.right * Time.deltaTime);
    }

    IEnumerator FireBullet() {
        while(true) {
            Instantiate(bullet, tr.position, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
}

