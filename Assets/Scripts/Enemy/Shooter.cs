using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float ratio;
    public float startDelay;
    public GameObject bullet;

    void Start()
    {
        InvokeRepeating("Shoot", startDelay, ratio);
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
