using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Animator animator;
    float speed = 8f;
    bool boom = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("BoomAnim",2f);

    }
    private void Update()
    {
        if (!boom)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            return;
        BoomAnim();
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(1);
        }
    }
    void BoomAnim()
    {
        boom = true;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Boom"))
            animator.SetTrigger("Boom");
    }
    private void Remove()
    {
        Destroy(this.gameObject);
    }
}
