using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird2 : Enemy
{
    enum BirdState
    {
        summon,
        attack,
        wind,
        idle,
        windAttack
    }
    public dasdd asasd;
    SpriteRenderer spriteRenderer;
    Animator animator;
    [SerializeField]
    Transform[] childTF = new Transform[3];
    BirdState curState=BirdState.idle;
    BirdState prevState = BirdState.idle;
    public GameObject yellowBirdPrefab;
    float sp = 100f;
    Rigidbody2D rb2D;
    Transform playerTransform;
    Vector2 target;
    Vector2 leftPos = new Vector2(-7.5f, 5.5f);
    Vector2 rightPos = new Vector2(10f, 5.5f);
    float asc = 0f;
    float mac = 200f;
    bool ies = false;
    bool isWindAttack = false;
    List<GameObject> birdList = new List<GameObject>();
    GameObject[] Bird = new GameObject[5];
    bool summonbird = false;
    public AudioClip aaaa;
    public AudioClip ddddd;
    public AudioClip ffff;
    public AudioClip atat;
    public AudioClip wdwd;
    public AudioClip spsp;
    AudioSource cxvxcv;
    void Start()
    {
        cxvxcv = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        rb2D = GetComponent<Rigidbody2D>();
        FindNear();
    }
    // Update is called once per frame
    void Update()
    {
        if (adad)
            return;
        switch (curState)
        {
            case BirdState.attack:
                Attack();
                break;
            case BirdState.idle:
                Idle();
                break;
            case BirdState.summon:
                Summon();
                break;
            case BirdState.wind:
                Wind();
                break;
            case BirdState.windAttack:
                WindAttack();
                break;
        }
    }
    void FixedUpdate()
    {
        if (adad)
            return;
        Moving();
    }
    void Wind()
    {
        if((Vector2.Distance(transform.position, leftPos) <= 0.1)|| (Vector2.Distance(transform.position, rightPos) <= 0.1))
        {
            target = new Vector2(target.x, -10);
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1f, LayerMask.GetMask("Platform"));
        if (hit)
        {
            target = transform.position;
            curState = BirdState.windAttack;
            isWindAttack = true;
        }
    }
    void WindAttack()
    {
        if (isWindAttack)
        {
            Invoke("windAttackEnd", 3f);
            isWindAttack = false;
            winasdasd();
        }
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 7)
        {
            Player player = playerTransform.gameObject.GetComponent<Player>();
            if (player)
            {
                player.KnockBack(transform.position, 10f);
                player.TakeDamage(0);
            }
        }
    }
    void winasdasd()
    {
        cxvxcv.PlayOneShot(spsp);
        if (curState == BirdState.windAttack)
            Invoke("winasdasd", spsp.length);
    }
    void windAttackEnd()
    {
        curState = BirdState.idle;
        FindNear();
    }

    void Summon()
    {
        if (!summonbird)
        {
            summonbird = true;
            StartCoroutine("CoSummon");
        }
    }
    IEnumerator CoSummon()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 YelloBirdPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject gameObject= Instantiate(yellowBirdPrefab, YelloBirdPosition, transform.rotation);
            YellowBird YellowBirdTarget = gameObject.GetComponent<YellowBird>();
            YellowBirdTarget.Init(2f + i * 0.5f, childTF[i], playerTransform);
             birdList.Add(gameObject);
            YellowBirdTarget.Died += () => birdList.Remove(gameObject);
            cxvxcv.PlayOneShot(spsp);
            yield return new WaitForSeconds(0.5f);
        }
        while (birdList.Count>0)
        {
            yield return null;
        }
        curState = BirdState.idle;
        summonbird = false;
        yield return null;
    }
    void Attack()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > 2)
        {
            target = playerTransform.position;
            asc += Time.deltaTime * 100f;
            if (asc > mac)
                asc = mac;
        }
        else
        {
            asc += Time.deltaTime * 150f;
            if (asc > mac)
                asc = mac;
            if (Vector2.Distance(transform.position, target) <= 0.5f && !ies)
            {
                animator.SetBool("Attacking", false);
                curState = BirdState.idle;
                FindNear();
            }
        }
    }
    void onAttack()
    {
        animator.SetBool("Attacking", true);
    }
    void Idle()
    {
        if (asc > 0)
        {
            asc -= Time.deltaTime * 70f;
        }
        else asc = 0f;
        if (!ies)
        {
            ies = true;
            Invoke("RandomEnum", 2f);
        }
        Bird = new GameObject[5];
    }

    void Moving()
    {
        float cs = Mathf.Clamp(sp + asc, sp, sp + mac);
        Vector2 dir = (target - (Vector2)transform.position).normalized;
        rb2D.velocity = dir * cs * Time.fixedDeltaTime;
        if (Mathf.Abs(dir.x) < 0.1){ if (dir.x > 0) transform.eulerAngles = new Vector3(0, 0, 0); else if (dir.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);}
        else{if (dir.x < 0) transform.eulerAngles = new Vector3(0, 0, 0); else if (dir.x > 0) transform.eulerAngles = new Vector3(0, 180, 0);}
        if (curState != BirdState.wind)
        {if (Vector2.Distance(transform.position, leftPos) < 0.2f && target == leftPos)target = rightPos;if (Vector2.Distance
                (transform.position, rightPos) < 0.2f && target == rightPos)target = leftPos;}
    }
    void RandomEnum()
    {
        asc = 0f;
        BirdState nextState = prevState;
        while (prevState == nextState)
        {
            nextState = (BirdState)Random.Range(0, 3);
        }
        curState = nextState;
        if (curState == BirdState.attack)
        {
            cxvxcv.PlayOneShot(atat);
            target = playerTransform.position;
            animator.SetTrigger("Attack");
        }
        else if (curState == BirdState.wind)
        {
            FindNear();
        }
        else
        {
            cxvxcv.PlayOneShot(ffff);
        }
        Debug.Log(curState);
        ies = false;
        prevState = curState;
    }
    public override void TakeDamage(int _hp)
    {
        if (curState == BirdState.windAttack)
        {
            hp -= _hp * 2;
        }
        else
        hp -= _hp;
        Dead();
        if(!adad)
            cxvxcv.PlayOneShot(aaaa);
    }
    protected override void Dead()
    {
        if (hp <= 0)
        {
            adad = true;
            animator.SetTrigger("asdasd");
            cxvxcv.PlayOneShot(ddddd);
        }
    }
    void asdasd()
    {
        asasd.StartCoroutine("sadsadads");
        Destroy(this.gameObject);
    }
    void FindNear()
    {
        target = Vector2.Distance(transform.position, leftPos) > Vector2.Distance(transform.position, rightPos) ? rightPos : leftPos;
    }
}
