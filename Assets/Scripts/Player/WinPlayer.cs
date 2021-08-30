using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlayer : MonoBehaviour
{
    GameObject winWindows;
    public GameObject pause;
    public GameObject winEffect;
    public Animator animator;
    Star[] stars = new Star[3];

    private void Awake()
    {
        stars[0] = GameObject.Find("star3").GetComponent<Star>();
        stars[1] = GameObject.Find("star2").GetComponent<Star>();
        stars[2] = GameObject.Find("star1").GetComponent<Star>();

    }
    void Start()
    {

        winWindows = GameObject.Find("WinUI");
        winWindows.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("win"))
        {
            Win();
        }
    }


    public void Win()
    {

        foreach (var star in stars)
        {
            if (star)
            {
                Debug.Log("Estrella activa");
                star.sendToWin();
            }

            else
            {
                Debug.Log("no se pudo activar la estrella");
            }
        }
        Instantiate(winEffect, transform.position, Quaternion.identity);
        animator.SetBool("isWin", true);
        //pause.SetActive(false);
        winWindows.SetActive(true);
    }
}
