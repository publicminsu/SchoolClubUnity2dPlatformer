using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : Enemy
{
    //public Transform Target;
    //public GameObject YellowBirdPrefab;
    //public GameObject WindPrefab;
    //public GameObject Wind1Prefab;
    //public float Speed = 5f;

    //bool StartPattern = false;
    //bool DownPattern = false;
    //bool UpPattern = false;
    //bool WindAttackPattern = false;
    //bool isLeft = true;
    
    //private Vector3 Position;
    //private GameObject RedBirdObject;

    //private Animator anAnimator;

    //private void Awake()
    //{
    //    StartCoroutine(Think());
    //}
    //void Start()
    //{
    //    anAnimator = GetComponent<Animator>();
    //}

    //void Update()
    //{
    //    if (!StartPattern)
    //    {
    //        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    //        Position = transform.position;
    //    }

    //    if (DownPattern)
    //    {
    //        Vector3 dir = Target.position - transform.position;

    //        transform.position += dir * 3f * Time.deltaTime;

    //        if (dir.x > 0)
    //        {
    //            transform.localScale = new Vector3(1, 1, 1);
    //        }
    //        else if (dir.x < 0)
    //        {
    //            transform.localScale = new Vector3(-1, 1, 1);
    //        }
    //    }

    //    if (WindAttackPattern)
    //    {
    //        transform.position += Vector3.down * 3.0f * Time.deltaTime;
    //    }

    //    if(UpPattern)
    //    {
    //        Vector3 distance = Position - transform.position;

    //        transform.position += distance * 3.0f * Time.deltaTime;
    //    }
    //}


    //IEnumerator Think()
    //{
    //    yield return new WaitForSeconds(0.2f);

    //    int RanAction = Random.Range(0, 3);
    //    switch (RanAction)
    //    {
    //        case 0:
    //            StartCoroutine(YellowBirdShoot());
    //            break;
    //        case 1:
    //            StartCoroutine(DownAttack());
    //            break;
    //        case 2:
    //            StartCoroutine(WindAttack());
    //            break;
    //    }
    //}

    //IEnumerator YellowBirdShoot()
    //{
    //    Vector3 YelloBirdPosition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
    //    GameObject Bird = Instantiate(YellowBirdPrefab, YelloBirdPosition, transform.rotation);

    //    YellowBird YellowBirdTarget = Bird.GetComponent<YellowBird>();
    //    YellowBirdTarget.Target = Target;

    //    yield return new WaitForSeconds(3.0f);

    //    StartCoroutine(Think());
    //}

    //IEnumerator DownAttack()
    //{
    //    StartPattern = true;
    //    DownPattern = true;

    //    yield return new WaitForSeconds(0.4f);

    //    DownPattern = false;
    //    UpPattern = true;
    //    yield return new WaitForSeconds(1.0f);
    //    UpPattern = false;
    //    StartPattern = false;
    //    yield return new WaitForSeconds(3.0f);
    //    StartCoroutine(Think());
    //}

    //IEnumerator WindAttack()
    //{
    //    StartPattern = true;
    //    WindAttackPattern = true;
        

    //    yield return new WaitForSeconds(3.2f);
        
    //    WindAttackPattern = false;
    //    UpPattern = true;

    //    yield return new WaitForSeconds(3.0f);
    //    UpPattern = false;
    //    StartPattern = false;

    //    StartCoroutine(Think());
    //}

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "EndPoint")
    //    {
    //        if (isLeft)
    //        {
    //            transform.eulerAngles = new Vector3(0, 180, 0);
    //            isLeft = false;
    //        }
    //        else
    //        {
    //            transform.eulerAngles = new Vector3(0, 0, 0);
    //            isLeft = true;
    //        }
    //    }

    //    if(other.gameObject.tag == "Platform" && WindAttackPattern)
    //    {
    //        Instantiate(WindPrefab, transform.position, transform.rotation);
    //        Instantiate(Wind1Prefab, transform.position, transform.rotation);
    //    }
    //}

}