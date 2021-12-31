using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public delegate void voidDelegate();
    public event voidDelegate Damaged;
    public event voidDelegate Dead;
    public event voidDelegate Resurrection;
    SpriteRenderer sr;
    private bool isDamaged = false;
    private bool isDead = false;
    public int hp = 3;
    PlayerMove playerMove;
    private Transform tr;
    public bool canRevive = false;
    public AudioClip TakeDamageAudio;
    public AudioClip ReviveAudio;
    AudioSource Audio;
    public bool stageasdasda=false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        playerMove = GetComponent<PlayerMove>();
        Damaged += () => Invoke("OffDamaged", 2);
        Damaged += () => GameManager.Instance.HpUpdate();
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            resurrection();
        }
    }
    public void TakeDamage(int _hp = 1)
    {
        if (isDamaged == true || isDead == true)
            return;
        if (hp - _hp <= 0 && isDead == false)
            OnDie();
        PlaySound("TakeDamage");
        sr.color= new Color(1, 1, 1, 0.4f);
        isDamaged = true;
        hp -= _hp;
        if (hp <= 0)
            hp = 0;
        Damaged();
    }
    public void TakeHeal(int _hp = 1)
    {
        if (hp < 3 && isDead == false)
            hp += _hp;
        GameManager.Instance.HpUpdate();
    }
    void OnDie()
    {
        isDead = true;
        if (Dead != null)
            Dead();
        Invoke("resurrection", 1);
    }
    void OffDamaged()
    {
        sr.color = new Color(1, 1, 1, 1);
        isDamaged = false;
    }
    public void KnockBack(Vector2 target, float power = 3f)
    {
        if (isDamaged == true || isDead == true)
            return;
        Vector2 dir = (target.x > transform.position.x) ? Vector2.right : Vector2.left;
        StartCoroutine(KnockBackCo(dir, power));
    }
    IEnumerator KnockBackCo(Vector2 dir, float power)
    {
        float KnockBackPower = power;
        float KnockbackTime = 0;
        while (KnockbackTime < 0.2f)
        {
            if (transform.rotation.y==0)
            {
                transform.Translate(-dir * KnockBackPower * Time.deltaTime);
            }
            else
            {
                transform.Translate(dir * KnockBackPower * Time.deltaTime);
            }
            KnockbackTime += Time.deltaTime;
            yield return null;
        }
    }
    void resurrection()
    {
        tr.localPosition = new Vector3(-8.2f, -0.0f, 0);
        isDead = false;
        isDamaged = false;
        hp = 3;
        GameManager.Instance.HpUpdate();
        PlaySound("Revive");
        if (Resurrection != null)
            Resurrection();
        if (stageasdasda)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void PlaySound(string action)
    {
        switch(action)
        {
            case "TakeDamage":
                Audio.clip = TakeDamageAudio;
                break;
            case "Revive":
                Audio.clip = ReviveAudio;
                break;
        }
        Audio.Play();
    }

    public void SpadeItem()
    {
        
    }
}
