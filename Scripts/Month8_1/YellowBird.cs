using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Enemy
{
    public delegate void voidDelegate();
    public event voidDelegate Died;
    public float Speed = 1f;
    public GameObject GoldSpadePrefab;
    float speed = 100f;
    float accSpeed = 0f;
    float maxAccSpeed = 200f;
    Transform playerTransform;
    Transform idleTransform;
    Rigidbody2D rb2D;
    Vector2 target;
    Vector2 pos;
    private Animator anAnimator;
    bool onAttack = false;
    bool isTracking = true;
    bool accFirstSpeed = false;
    float attackTime;
    public void Init(float _attackTime, Transform idleTF, Transform playerTF)
    {
        attackTime = _attackTime;
        idleTransform = idleTF;
        playerTransform = playerTF;
    }
    void Start()
    {
        anAnimator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        target = playerTransform.transform.position;
        Invoke("OnAttack", attackTime);
    }
    void OnAttack()
    {
        onAttack = true;
    }
    void Update()
    {
        if (!onAttack)
            Idle();
        if (onAttack && isTracking)
            Attack();
    }
    void FixedUpdate()
    {
        Moving();
    }
    void Idle()
    {
        target = idleTransform.position;
        transform.position = Vector2.Lerp(transform.position, target,0.005f);
    }
    void Attack()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > 2)
        {
            target = playerTransform.position;
            accSpeed += Time.deltaTime * 100f;
            if (accSpeed > maxAccSpeed)
                accSpeed = maxAccSpeed;
        }
        else
        {
            accSpeed += Time.deltaTime * 150f;
            if (accSpeed > maxAccSpeed)
                accSpeed = maxAccSpeed;
            if (Vector2.Distance(transform.position, target) <= 0.5f)
            {
                pos = new Vector2((target - (Vector2)transform.position).normalized.x, 1);
                isTracking = false;
                Destroy(this.gameObject, 3f);
            }
        }
    }
    void Moving()
    {
        if (!onAttack)
            return;
        float curSpeed = Mathf.Clamp(speed + accSpeed, speed, speed + maxAccSpeed);
        Vector2 dir;
        if (isTracking)
            dir = (target - (Vector2)transform.position).normalized;
        else
            dir = pos;
        rb2D.velocity = dir * curSpeed * Time.fixedDeltaTime;
        if (rb2D.velocity.x < 0) transform.eulerAngles = new Vector3(0, 0, 0); else if (rb2D.velocity.x > 0) transform.eulerAngles = new Vector3(0, 180, 0);
    }
    protected override void Dead()
    {
        base.Dead();
        Instantiate(GoldSpadePrefab, transform.position, transform.rotation);
        Died();
    }
    private void OnDestroy()
    {
        Died();
    }
}
