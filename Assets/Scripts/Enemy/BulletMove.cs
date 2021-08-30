using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);
    }
}
