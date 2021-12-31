using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    AudioSource ad;
    Animator animator;
    Rigidbody2D rigidbody2;
    Transform playerTF;
    public AudioClip adc;
    public GameObject asdasd;
    void Start()
    {
        ad = GetComponent<AudioSource>();
        ad.PlayOneShot(adc);
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTF = FindObjectOfType<Player>().gameObject.transform;
    }

    // Update is called once per frame

    void FrogJumping()
    {
        ad.Play();
        Vector2 targetPos = (playerTF.position - transform.position).normalized;
        Vector2 sadasd = new Vector2(targetPos.x * Random.Range(1.0f, 2.5f), targetPos.y * Random.Range(1.0f, 1.3f));
        if (targetPos.x > 0) transform.eulerAngles = new Vector3(0, 0, 0); else if (targetPos.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        rigidbody2.AddForce(sadasd + Vector2.up * 4f, ForceMode2D.Impulse);
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        animator.SetTrigger("End");
        Invoke("ResetJump", 1f);
    }
    protected override void Dead()
    {
        base.Dead();
        if (hp <= 0)
        {
            Instantiate(asdasd, transform.position, transform.rotation);
        }
    }
    void ResetJump()
    {
        if (adad)
            return;
        CancelInvoke("ResetJump");
        animator.SetTrigger("Reset");
    }
}
