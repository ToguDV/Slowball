﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public GameObject puntoB;
    public GameObject puntoA;
    public GameObject puntoC;
    public Rigidbody2D rigidbody2D;
    Vector3 worldPosition;
    public float normTime;
    public float slowTime;
    public float speed;
    public float maxSpeed;
    Vector3 lastVelocity;
    public float maxLineTarget;
    private LineRendererController lineRendererController;
    public static bool isSlow;
    public static float speedStatic;
    public delegate void ChangeTime();
    public static event ChangeTime Onslow;
    public delegate void PlayerInfo();
    public static event PlayerInfo OnFirstClick;
    private bool firstClick;
    private bool onceDrag;


    private void Awake()
    {
        Application.targetFrameRate = 60;

        firstClick = true;
        onceDrag = false;
        lineRendererController = GameObject.Find("Linerenderer").GetComponent<LineRendererController>();
        speedStatic = slowTime;
    }
    void Start()
    {
        isSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigidbody2D.linearVelocity;
    }

    void FixedUpdate()
    {
        
        if (!DeathPlayer.isDead)
        {
            rigidbody2D.linearVelocity = Vector2.ClampMagnitude(rigidbody2D.linearVelocity, maxSpeed);
        }


    }

    private void OnDisable()
    {
        EsconderLineas();
        rigidbody2D.linearVelocity = Vector2.zero;
    }


    private void OnMouseDrag()
    {
        if (!btnPause.isPaused)
        {

            if (!DeathPlayer.isDead)
            {

                if (OnFirstClick != null)
                {
                    if (firstClick)
                    {
                        OnFirstClick();
                        firstClick = false;
                    }

                }
                Time.timeScale = slowTime;
                ActualizarLineas();
                isSlow = true;

                if (Onslow != null && !onceDrag)
                {
                    Onslow();
                }

                onceDrag = true;
            }

            else
            {

            }

        }

    }

    private void OnMouseUp()
    {
        if (!btnPause.isPaused)
        {
            if (!DeathPlayer.isDead)
            {
                Time.timeScale = normTime;
                EsconderLineas();
                isSlow = false;

                if (Onslow != null && onceDrag)
                {
                    Onslow();
                }
                onceDrag = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rigidbody2D.linearVelocity = direction * Mathf.Max(speed, 0f);
    }

    public void ActualizarLineas()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        puntoC.transform.position = worldPosition;
        puntoA.transform.localPosition = puntoC.transform.localPosition * -1.3f;
        puntoA.transform.localPosition = Vector3.ClampMagnitude(puntoA.transform.localPosition, maxLineTarget);
        for (int i = 0; i < lineRendererController.points.Length; i++)
        {
            lineRendererController.lineRenderer.SetPosition(i, lineRendererController.points[i].position);
        }
    }

    public void EsconderLineas()
    {
        if (puntoA.transform.position != puntoB.transform.position)
        {
            puntoA.transform.position = puntoB.transform.position;
            puntoC.transform.position = puntoB.transform.position;
            rigidbody2D.linearVelocity = (lineRendererController.lineRenderer.GetPosition(1) - lineRendererController.lineRenderer.GetPosition(2)) * speed;
            for (int i = 0; i < lineRendererController.points.Length; i++)
            {
                lineRendererController.lineRenderer.SetPosition(i, lineRendererController.points[i].position);
            }

        }
    }

    public void setFirstClick(bool value)
    {
        firstClick = value;
    }

    
}
