using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWithRotation : MonoBehaviour
{
    public float offset;
    private GameObject target;
    public float rotationSpeed;

    private Vector2 direction;
    Quaternion rotation;

    void Start()
    {
        Invoke("SetTarget", 2f);
    }

    private void SetTarget()
    {
        TargetSetter targetSetter = gameObject.GetComponentInParent<TargetSetter>();
        target = targetSetter.target;
    }
    void Update()
    {
        if(target!= null)
        RotateTowards(target.transform.position);
    }

    private void RotateTowards(Vector2 target)
    {
        direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
