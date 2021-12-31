using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    Transform tr;
	public float fvelocity;
    public Transform tftarget;
    public Vector3 dir;


	void Start ()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(DestroySelf());
        tftarget = GameObject.Find ("Player").transform;
        // vector = tftarget.position;

        dir = tftarget.position - transform.position;
	}
	
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, dir*100, Time.deltaTime * fvelocity);
	}

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if (other.gameObject.tag == "Player") {
        //     Destroy(this.gameObject);
        // }
        if (other.gameObject.tag == "Platform") {
            Destroy(this.gameObject);
        }
    }
}