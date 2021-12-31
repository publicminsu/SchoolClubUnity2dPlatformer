using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Month3_flower : EnemyBullet
{
    public GameObject z;
    public float speed;
    Rigidbody2D rb2D;
    Animator an;
    Vector2 targetPos;
    public bool isUsed = false;
    bool isAttack = false;
    bool isGround = false;
    bool isLeft;
    // Update is called once per frame
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        GameObject.FindObjectOfType<Player>().Dead += () => { if (isAttack || isGround) this.gameObject.SetActive(false); };
    }
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (isAttack)
        {
            Vector2 dir = (targetPos - (Vector2)transform.position).normalized;
            rb2D.AddForce(dir*speed, ForceMode2D.Impulse);
            isAttack = false;
        }

    }
    public void TargetInit(Transform targetTF)
    {
        isAttack = true;
        targetPos = targetTF.position;
        if (((Vector2)transform.position - targetPos).x > 0) isLeft = true; else isLeft = false;
    }
    void OnDisable()
    {
        isGround = false;
        isUsed = false;
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            player.KnockBack(transform.position);
            player.TakeDamage(damage);
            this.gameObject.SetActive(false);
            Instantiate(z, this.transform.position, this.transform.rotation);
        }
        else if (!isGround && !other.gameObject.CompareTag("Enemy"))
        {
            isGround = true;
            StartCoroutine("clearFlower");
        }
    }
    IEnumerator clearFlower()
    {
        Instantiate(z, this.transform.position, this.transform.rotation);

        this.gameObject.SetActive(false);
        yield return null;
    }
}
