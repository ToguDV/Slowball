using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetSetter : MonoBehaviour
{
    public AIDestinationSetter aIDestinationSetter;
    public GameObject target;
    public string nameTarget;

    void Start()
    {
        Invoke("SetTarget", 1f);
    }

    private void SetTarget()
    {
        target = GameObjectManager.Instance.GameObjectDictionary[nameTarget];
        aIDestinationSetter.target = target.transform;
    }
}
