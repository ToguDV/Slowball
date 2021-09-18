using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    public ArenaLoader arenaLoader;
    public GameObject templateDeath;
    public GameObject btnRevive;
    public static bool isDead;
    public int maxRevives = 1;
    int currentRevives;

    private void OnEnable()
    {
        BtnRevive.onRevive += Revivir;
    }

    private void Awake()
    {
        currentRevives = 0;
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            Time.timeScale = 1f;
            templateDeath.SetActive(true);
            if(currentRevives >= maxRevives)
            {
                btnRevive.SetActive(false);
            }
        }
    }

    private void Revivir()
    {
        currentRevives++;
        templateDeath.SetActive(false);
        isDead = false;
    }
}
