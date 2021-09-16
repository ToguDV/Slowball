using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallShooterDeathManager : MonoBehaviour
{
    public Animator animator;
    public GameObject father;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isDead"))
        {
            Destroy(father);
        }
    }
}
