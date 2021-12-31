using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake : Enemy
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Collider2D AttackCol;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void onAttackAnimation()
    {
        AttackCol.enabled = true;
    }
    protected override void Dead()
    {
        AttackCol.enabled = false;
        StartCoroutine("clearFake");
    }

    IEnumerator clearFake()
    {
        float timeUse = 0.5f;
        float time = 1f;
        Color color = spriteRenderer.color;
        while (spriteRenderer.color.a > 0f)
        {
            time -= Time.deltaTime / timeUse;
            color.a = Mathf.Lerp(0, 1, time);
            spriteRenderer.color = color;
            yield return null;
        }
        Destroy(this.gameObject);
        yield return null;
    }
}
