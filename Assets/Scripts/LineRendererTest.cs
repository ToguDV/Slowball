using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineRendererController lineRC;
    void Start()
    {
        lineRC.SetUpLine(points);
    }

}
