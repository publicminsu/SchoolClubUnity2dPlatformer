using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
    void OnCollisionStay2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            player.KnockBack(other.contacts[0].point);
            player.TakeDamage(damage);
        }
    }
}
