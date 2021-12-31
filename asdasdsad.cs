using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class asdasdsad : MonoBehaviour
{
    TilemapCollider2D cadsd;
    Tilemap sasd;
    void Start()
    {
        sasd = GetComponent<Tilemap>();
        cadsd = GetComponent<TilemapCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) StartCoroutine("dasdasd");
    }
    IEnumerator dasdasd()
    {
        float timeUse = 1f;
        float time = 1f;
        Color color = sasd.color;
        while (sasd.color.a > 0f)
        {
            time -= Time.deltaTime / timeUse;
            color.a = Mathf.Lerp(0, 1, time);
            sasd.color = color;
            yield return null;
        }
        cadsd.enabled = false;
        yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine("asdadad");
    }
    IEnumerator asdadad()
    {
        cadsd.enabled = true;
        float timeUse = 0.5f;
        float time = 1f;
        Color color = sasd.color;
        while (sasd.color.a < 1f)
        {
            time -= Time.deltaTime / timeUse;
            color.a = Mathf.Lerp(1, 0, time);
            sasd.color = color;
            yield return null;
        }
        yield return null;
    }
}
