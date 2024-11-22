using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Rotational Speed
    public float speed = 0f;

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;
    public bool aleatorizar = false;
    private Vector3 rotationAxis;
    private void Start()
    {
        if (aleatorizar)
        {
            speed = Random.Range(speed - (speed * 0.6f), speed + (speed * 0.5f));
        }
        rotationAxis = new Vector3(ForwardX ? 1 : 0, ForwardY ? 1 : 0, ForwardZ ? 1 : 0);
    }

    void Update()
    {
        //Forward Direction
        transform.Rotate(speed * Time.deltaTime * rotationAxis, Space.Self);

    }
}