using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    public ArenaLoader arenaLoader;
    public GameObject templateDeath;
    public GameObject btnRevive;
    public GameObject btnQuit;
    public static bool isDead;
    public int maxRevives = 1;
    int currentRevives;
    public Animator animator;
    public GameObject deathEffect;
    public ThrowController throwController;
    public delegate void DeathAction();
    public static event DeathAction onDeath;
    public float restartDelay;
    bool once;

    private void OnEnable()
    {
        BtnRevive.onRevive += Revivir;
    }

    private void OnDisable()
    {
        BtnRevive.onRevive -= Revivir;
    }

    private void Awake()
    {
        once = true;
        currentRevives = 0;
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && once)
        {
            once = false;
            if(onDeath != null)
            {
                onDeath();
            }
            PlayerPrefs.SetInt("currentDeaths", PlayerPrefs.GetInt("currentDeaths", 0) + 1);
            throwController.enabled = false;
            Instantiate(deathEffect, transform.position, transform.rotation);
            animator.SetBool("IsDeath", true);
            isDead = true;
            Time.timeScale = 1f;
            templateDeath.SetActive(true);
            btnQuit.SetActive(true);
            if (currentRevives >= maxRevives)
            {
                btnQuit.SetActive(false);
                btnRevive.SetActive(false);
                Invoke("loadArena", restartDelay);

            }
            //No ha revivido mucho
            else
            {
                PlayerPrefs.SetFloat("currentPlayTime", ArenaScoreboard.time + PlayerPrefs.GetFloat("currentPlayTime", 0f));
                Debug.Log("CurrentPlayTime:" + PlayerPrefs.GetFloat("currentPlayTime", 0f));
                Debug.Log("CurrenDeaths:" + PlayerPrefs.GetInt("currentDeaths", 0));
                if(PlayerPrefs.GetFloat("currentPlayTime", 0f) >= AdsManager.timeToShowReward && PlayerPrefs.GetInt("currentDeaths", 0) >= AdsManager.deathsToShowReward)
                {
                    PlayerPrefs.SetInt("currentDeaths", 0);
                    btnRevive.SetActive(true);
                }

                else
                {
                    btnQuit.SetActive(false);
                    btnRevive.SetActive(false);
                    Invoke("loadArena", restartDelay);
                }
            }
        }
    }

    private void loadArena()
    {
        arenaLoader.loadArena();
    }

    private void Revivir()
    {
        once = true;
        animator.SetBool("IsDeath", false);
        currentRevives++;
        templateDeath.SetActive(false);
        isDead = false;
        throwController.enabled = true;
    }
}
