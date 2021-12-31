using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    public float speed;
    public float fbdistance;
    public LayerMask lmisLayer;
  
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, fbdistance, lmisLayer);
        if(ray.collider != null)
        {
            if(ray.collider.tag == "Enemy")
            {
                Debug.Log("명중!!");
                ray.collider.GetComponent<Enemy>().TakeDamage(1);

            }
            DestroyBullet();
        }
        if(transform.rotation.y ==0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
     

    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
}
