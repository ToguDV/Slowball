using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public float[] timeLimits;
    private float time;
    public Star[] stars;
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeLimits[0])
        {
            stars[0].quitar();
        }

        if (time >= timeLimits[1])
        {
            stars[1].quitar();
        }

        if (time >= timeLimits[2])
        {
            stars[2].quitar();
        }
    }
}
