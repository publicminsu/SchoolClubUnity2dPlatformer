using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    //정신집중(풀)->공격
    //텔레포트->(분신)공격
    //랜덤 돌려주는곳 하나있기.
    Animator animator;
    public Transform Left;
    public Transform Right;
    public GameObject fakePrefab;
    public GameObject frogPrefab;
    public Collider2D AttackCol;
    public AudioClip tel;
    SpriteRenderer spriteRenderer;
    int ds = 0;
    int ddds = 0;
    int ddd = 0;
    AudioSource adsa;
    public GameObject asdadasd;
    void Start()
    {
        adsa = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator.SetTrigger("Teleport");
        //animator.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void TakeDamage(int _hp)
    {
        int Temp = ddds + _hp;
        ds += Temp;
        base.TakeDamage(Temp);
        if (adad)
            return;
        if (ds >= 10)
        {
            ds = 0;
            animator.SetTrigger("ATT");
        }
    }
    protected override void Dead()
    {
        if (hp <= 0)
            animator.SetTrigger("asd");
    }
    void asdasd()
    {
        asdadasd.SetActive(true);
        base.Dead();
    }
    void MD(int temp)
    {
        ddds = temp;
    }
    void AT(int temp)
    {
        if (temp == 1)
        {
            adsa.Play();
        }
        AttackCol.enabled = (temp == 1 ? true : false);
    }
    void DCS() { ddd++; if (ddd > 3) { ddd -= 3; int a = Random.Range(0, 2); if (a == 1) animator.SetTrigger("Teleport"); else animator.SetTrigger("Spawn"); } }
    void SpawnFrog()
    {
        Vector3 FrogSpawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject gameObject = Instantiate(frogPrefab, FrogSpawnPos, transform.rotation);
    }
    IEnumerator TeleportStart()
    {
        bool fakeSpawnBool = false;
        float timeUse = 1f;
        float time = 1f;
        Color color = spriteRenderer.color;
        while (spriteRenderer.color.a > 0f)
        {
            time -= Time.deltaTime / timeUse;
            color.a = Mathf.Lerp(0, 1, time);
            spriteRenderer.color = color;
            if (spriteRenderer.color.a < 0.2f&& !fakeSpawnBool)
            {
                adsa.PlayOneShot(tel);
                Vector3 FakeSpawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject gameObject = Instantiate(fakePrefab, FakeSpawnPos, transform.rotation);
                fakeSpawnBool = true;
            }

            yield return null;
        }
        float gapLeft, gapRight;
        gapLeft = Mathf.Abs(Left.position.x - transform.position.x);
        gapRight = Mathf.Abs(Right.position.x - transform.position.x);
        if (gapLeft < gapRight)
        {
            transform.position = Right.position;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (gapLeft > gapRight)
        {
            transform.position = Left.position;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        yield return StartCoroutine("TeleportEnd");
    }
    IEnumerator TeleportEnd()
    {
        animator.SetTrigger("TeleportEnd");
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
        yield return null;
    }

}
