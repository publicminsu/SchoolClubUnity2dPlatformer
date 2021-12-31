using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop : EnemyBullet
{
    Collider2D collider2;
    Rigidbody2D rigidbody2;
    Animator animator;
    private void Awake()
    {
        collider2 = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rigidbody2.gravityScale = 1;
        animator.SetBool("dropSet", false);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();
        if (playerMove)
        {
            playerMove.SpeedDebuff();
        }
        rigidbody2.gravityScale = 0;
        rigidbody2.velocity = Vector2.zero;
        animator.SetBool("dropSet",true);
    }   
    void dropend()
    {
        RainSpawn.instance.InsertQueue(this.gameObject);
    }
}
