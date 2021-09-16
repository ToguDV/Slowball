using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWithRotation : MonoBehaviour
{
    public float offset;
    private GameObject target;
    public float rotationSpeed;
    void Start()
    {
        target = GameObject.Find("bola neon");
    }

    // Update is called once per frame
    void Update()
    {
        if(target!= null)
        RotateTowards(target.transform.position);
    }

    private void RotateTowards(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
