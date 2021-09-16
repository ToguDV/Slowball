using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float ratio;
    public float startDelay;
    public float anticipationRatio = 0.9f;
    public GameObject bullet;
    public SpriteRenderer sprite;

    void Start()
    {
        sprite.enabled = false;
        InvokeRepeating("Shoot", startDelay, ratio);
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        sprite.enabled = false;
        Invoke("SpriteEnable", ratio * anticipationRatio);
    }

    void SpriteEnable()
    {
        sprite.enabled = true;
    }
}
