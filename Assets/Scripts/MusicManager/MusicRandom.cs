using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandom : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private void OnEnable()
    {
        RestartFast.onRestart += pickRandomMusic;
    }

    private void OnDisable()
    {
        RestartFast.onRestart -= pickRandomMusic;
    }

    void Start()
    {
        pickRandomMusic();   
    }

    void pickRandomMusic()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
