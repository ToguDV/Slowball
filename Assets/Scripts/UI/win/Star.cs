using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    Animator animator;
    private bool disabled;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("send", false);
    }

    public void quitar()
    {
        disabled = true;
    }

    public void sendToWin()
    {
        if (!disabled)
        {
            animator.SetBool("send", true);
        }
        
    }

    
}
