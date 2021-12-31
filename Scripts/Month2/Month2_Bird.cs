using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month2_Bird : MonoBehaviour
{
    private float fSpawnMin = 1.0f;
    private float fSpawnMax = 2.5f;
    private float fSpawnTime;
    private float fFlowerSpeed = 8f;
    public GameObject prefab_flower;
    
    AudioSource audio;
    public AudioClip BulletAttack;
    Animator animator;
    Transform target=null;
    // Start is called before the first frame update
    void Start()
    {
        fSpawnTime = Random.Range(fSpawnMin, fSpawnMax);
        animator = GetComponent<Animator>();
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (fSpawnTime < 0)
            {
                fSpawnTime = Random.Range(fSpawnMin, fSpawnMax);
                animator.SetTrigger("Charging");
            }
            else fSpawnTime -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        if (!target)
            return;
        Vector2 dir = (target.position - transform.position).normalized;
        if (dir.x < 0) transform.eulerAngles = new Vector3(0, 0, 0); else if (dir.x > 0) transform.eulerAngles = new Vector3(0, 180, 0);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion quat = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
        GameObject flower = Instantiate(prefab_flower, transform.position, quat);
        flower.GetComponent<Rigidbody2D>().AddForce(fFlowerSpeed * dir, ForceMode2D.Impulse);
        this.audio.PlayOneShot(BulletAttack);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            target = other.gameObject.transform;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            target = null;
    }
}
