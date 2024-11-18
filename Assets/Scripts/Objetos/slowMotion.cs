using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    public float speedPersonal = 1;
    bool palanca = false;


    private void OnEnable()
    {
        ThrowController.Onslow += CambiarVelocidad;
    }

    private void OnDisable()
    {
        ThrowController.Onslow -= CambiarVelocidad;
    }

    void Start()
    {
        ObtenerComponentes();
    }

    // Update is called once per frame
    void Update()
    {






    }

    public void ObtenerComponentes()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();


    }

    void CambiarVelocidad()
    {


        if (!palanca)
        {
            if (animator)
            {

                animator.speed = ThrowController.speedStatic * speedPersonal;
            }

            if (rigidbody2D)
            {
                rigidbody2D.linearVelocity *= ThrowController.speedStatic;
            }
            palanca = true;
        }

        else
        {
            Debug.Log("todo normalizado pa");
            if (animator)
            {

                animator.speed = 1;
            }

            if (rigidbody2D)
            {
                rigidbody2D.linearVelocity *= ThrowController.speedStatic;
            }
            palanca = false;
        }



    }
}
