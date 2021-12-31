using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dasdd : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D bxd;
    private void Start()
    {
        bxd = GetComponent<BoxCollider2D>();
        bxd.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public IEnumerator sadsadads()
    {
        float timeUse = 2f;
        float time = 1f;
        Color color = spriteRenderer.color;
        while (spriteRenderer.color.a < 1f)
        {
            time -= Time.deltaTime / timeUse;
            color.a = Mathf.Lerp(1, 0, time);
            spriteRenderer.color = color;
            yield return null;
        }
        bxd.enabled = true;
        yield return null;
    }
}
