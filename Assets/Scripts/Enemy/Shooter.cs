using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Shooter : MonoBehaviour
{
    public float ratio;
    public float startDelay;
    public float anticipationRatio = 0.9f;
    public GameObject bullet;
    public SpriteRenderer sprite;
    public static bool canShoot;
    public static bool temp;
    public bool hasAiPath = true;
    private AIPath aIPath;

    private void Awake()
    {
        if (hasAiPath)
        {
            aIPath = GetComponentInParent<AIPath>();
        }

        if (!temp)
        {
            canShoot = true;
        }

        else
        {
            setSeguimiento(false);
        }
    }

    private void OnEnable()
    {
        DeathPlayer.onDeath += DesactivarShooter;
        BtnRevive.onRevive += ActivarShooter;
    }

    private void OnDisable()
    {
        DeathPlayer.onDeath -= DesactivarShooter;
        BtnRevive.onRevive -= ActivarShooter;
    }

    private void OnDestroy()
    {
        DeathPlayer.onDeath -= DesactivarShooter;
        BtnRevive.onRevive -= ActivarShooter;
    }

    void Start()
    {
        sprite.enabled = false;
        if (canShoot)
        {
            Invoke("SpriteEnable", ratio * anticipationRatio);
            InvokeRepeating("Shoot", startDelay, ratio);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        sprite.enabled = false;
        Invoke("SpriteEnable", ratio * anticipationRatio);
    }

    public void DesactivarShooter()
    {
        setSeguimiento(false);
        temp = true;
        canShoot = false;
        sprite.enabled = false;
        CancelInvoke("Shoot");
        CancelInvoke("SpriteEnable");
    }

    public void ActivarShooter()
    {
        setSeguimiento(true);
        temp = false;
        canShoot = true;
        Invoke("SpriteEnable", ratio * anticipationRatio);
        InvokeRepeating("Shoot", startDelay, ratio);
    }

    void SpriteEnable()
    {
        sprite.enabled = true;
    }

    void setSeguimiento(bool value)
    {
        if (hasAiPath)
        {
            aIPath.canMove = value;
        }
    }
}
