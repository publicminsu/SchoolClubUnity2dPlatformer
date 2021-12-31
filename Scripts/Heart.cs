using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Up()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Down"))
        {
            return;
        }
        animator.SetTrigger("Up");
    }
    public void Down()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Up"))
        {
            return;
        }
        animator.SetTrigger("Down");
    }
}
