using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandom : MonoBehaviour
{
    public Sprite[] backgrounds;
    public SpriteRenderer background;

    private void OnEnable()
    {
        RestartFast.onRestart += RandomBackground;
    }

    private void OnDisable()
    {
        RestartFast.onRestart -= RandomBackground;
    }

    void Awake()
    {
        RandomBackground();
    }

    public void RandomBackground()
    {
        background.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }
}
