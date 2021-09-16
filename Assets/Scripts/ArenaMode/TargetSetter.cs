using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetSetter : MonoBehaviour
{
    public AIDestinationSetter aIDestinationSetter;
    GameObject target;
    public string nameTarget;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("bola neon");
        aIDestinationSetter.target = target.transform;
    }
}
