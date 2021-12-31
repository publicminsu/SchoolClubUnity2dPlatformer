using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            player.KnockBack(transform.position);
            player.TakeDamage(damage);
        }
        if (!other.gameObject.CompareTag("Enemy"))
            Destroy(this.gameObject);
    }
}
