using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandom : MonoBehaviour
{
    public Sprite[] backgrounds;
    public SpriteRenderer background;
   void Awake()
    {
        background.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }
}
