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
    public static bool canShoot;
    public static bool temp;
    public bool hasAiPath = true;
    private bool alreadyShoot;

    private void Awake()
    {
        sprite.enabled = false;
        ratio = Random.Range(ratio, ratio * 1.5f + 1);
        if (hasAiPath)
        {
            //aIPath = GetComponentInParent<AIPath>();
        }

        if (!temp)
        {
            ActivarShooter();
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


    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        sprite.enabled = false;
    }

    public void DesactivarShooter()
    {
        alreadyShoot = false;
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
        InvokeRepeating("SpriteEnable", startDelay*anticipationRatio, ratio * anticipationRatio);
        InvokeRepeating("Shoot", startDelay, ratio);
        alreadyShoot = true;
    }

    void SpriteEnable()
    {
        sprite.enabled = true;
    }

    void setSeguimiento(bool value)
    {
        if (hasAiPath)
        {
            //aIPath.canMove = value;
        }
    }
}
