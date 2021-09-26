using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathRedBall : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public GameObject efectoMuerte;
    public GameObject father;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Matar();
        }
    }

    public void Matar()
    {
        if (!animator.GetBool("isDead"))
        {
            Vibrator.Vibrate(50);
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        }

        animator.SetBool("isDead", true);
        Invoke("Destruir", 3f);
    }

    public void Destruir()
    {
        Destroy(father);


    }
}
