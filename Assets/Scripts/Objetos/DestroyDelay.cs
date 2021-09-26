using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    public float delay = 5f;
    void Start()
    {
        Invoke("Destroy", delay);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
