using System.Collections;
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
    public LineRendererController lineRendererController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
    }


    private void OnMouseDrag()
    {
        for (int i = 0; i < lineRendererController.points.Length; i++)
        {
            lineRendererController.lineRenderer.SetPosition(i, lineRendererController.points[i].position);
        }
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        puntoC.transform.position = worldPosition;
        puntoA.transform.localPosition = puntoC.transform.localPosition * -1.3f;
        puntoA.transform.localPosition = Vector3.ClampMagnitude(puntoA.transform.localPosition, maxLineTarget);
        Time.timeScale = slowTime;
    }

    private void OnMouseUp()
    {
        Time.timeScale = normTime;
        puntoA.transform.position = puntoB.transform.position;
        puntoC.transform.position = puntoB.transform.position;
        rigidbody2D.velocity = (lineRendererController.lineRenderer.GetPosition(1) - lineRendererController.lineRenderer.GetPosition(2)) * speed;
        for (int i = 0; i < lineRendererController.points.Length; i++)
        {
            lineRendererController.lineRenderer.SetPosition(i, lineRendererController.points[i].position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rigidbody2D.velocity = direction * Mathf.Max(speed, 0f);
    }
}
