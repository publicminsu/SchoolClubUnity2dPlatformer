using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool adad = false;
    //콜라이더 충돌 전용.
    public int hp = 3;
    public int damage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            player.KnockBack(transform.position);
            player.TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            player.KnockBack(transform.position);
            player.TakeDamage(damage);
        }
    }
    public virtual void TakeDamage(int _hp)
    {
        hp -= _hp;
        Dead();
    }
    protected virtual void Dead()
    {
        if (hp <= 0)
        {
            adad = true;
            Destroy(gameObject);
        }
    }
}
