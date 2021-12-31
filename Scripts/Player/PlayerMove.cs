using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float baseSpeed = 200f;
    public float debufSpeed = 0f;
    public float jumpPower;
    Rigidbody2D rgPrigid;
    Animator anPanim;
    private float fatkTime;
    public float fatkcoolTime = 0.5f;
    public Transform tranatkpos;
    public Vector2 vboxSize;
    public GameObject bullet;
    public Transform tranbulletpos;
    bool isJumping = false;
    bool onGround = false;
    float JumpTimer = 0f;
    float JumpTimeLimit = 0.2f;
    public bool notMove = false;
    public bool bulletstate = false;
    public AudioClip JumpAudio;
    public AudioClip att1;
    public AudioClip att2;
    public AudioClip ite;
    AudioSource Audio;

    public void auasdasd()
    {
        Audio.PlayOneShot(ite);
    }
    void Awake()
    {
        var obj = FindObjectsOfType<PlayerMove>(); 
        if (obj.Length == 1) { DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); return; }
        GetComponent<Player>().Damaged += () => anPanim.SetTrigger("Damaged");
        rgPrigid = GetComponent<Rigidbody2D>();
        anPanim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (notMove)
            return;
        if (fatkTime <= 0)
        {
            if (Input.GetKey(KeyCode.X) && bulletstate == true)
            {
                PlaySound("att2");
                Range();
            }
            if (Input.GetKey(KeyCode.Z))
            {
                PlaySound("att1");
                Melee();
            }
        }
        else
        {
            fatkTime -= Time.deltaTime;
        }
        if (onGround && Input.GetButtonDown("Jump"))
        {
            PlaySound("JUMP");
            isJumping = true;
            JumpTimer = JumpTimeLimit;
            rgPrigid.velocity = Vector2.up * jumpPower;
        }
        if (Input.GetButton("Jump") && isJumping)
        {
            if (JumpTimer > 0)
            {
                rgPrigid.velocity = Vector2.up * jumpPower;
                JumpTimer -= Time.deltaTime;
            }
            else isJumping = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
    void Range()
    {
        Instantiate(bullet, tranbulletpos.position, transform.rotation);
        anPanim.SetTrigger("isRange");
        fatkTime = fatkcoolTime;
        bulletstate = false;
    }
    void Melee()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(tranatkpos.position, vboxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(1);
            }
        }
        anPanim.SetTrigger("isATK");
        fatkTime = fatkcoolTime;
    }
    void FixedUpdate()
    {

        RaycastHit2D hit1 = Physics2D.Raycast(rgPrigid.position + Vector2.right * 0.25f, Vector2.down, 0.7f, LayerMask.GetMask("Platform"));
        RaycastHit2D hit2 = Physics2D.Raycast(rgPrigid.position + Vector2.left * 0.25f, Vector2.down, 0.7f, LayerMask.GetMask("Platform"));
        float Hor = Input.GetAxisRaw("Horizontal");
        if (Hor == 0) anPanim.SetBool("isWalking", false); else anPanim.SetBool("isWalking", true);
        if (Hor > 0) transform.eulerAngles = new Vector3(0, 0, 0); else if (Hor < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        float resultSpeed = baseSpeed - debufSpeed * baseSpeed * 0.1f;
        rgPrigid.velocity = new Vector2(Hor * resultSpeed * Time.fixedDeltaTime, rgPrigid.velocity.y);
        if (hit1.collider != null || hit2.collider != null)
        {
            anPanim.SetBool("isJumping", false);
            onGround = true;
        }
        else
        {
            if (isJumping)
                anPanim.SetBool("isJumping", true);
            onGround = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(tranatkpos.position, vboxSize);
    }

    public void SpeedDebuff()
    {
        if (debufSpeed > 5)
            return;
        debufSpeed++;
        CancelInvoke("DecreaseDebuff");
        Invoke("DecreaseDebuff", 1f);
    }
    private void DecreaseDebuff()
    {
        if (debufSpeed <= 0)
            return;
        debufSpeed--;
        Invoke("DecreaseDebuff", 1f);
    }



    void PlaySound(string action)
    {
        switch(action)
        {
            case "JUMP":
                Audio.clip = JumpAudio;
                break;
            case "att1":
                Audio.clip = att1;
                break;
            case "att2":
                Audio.clip = att2;
                break;
        }
        Audio.Play();
    }
}
