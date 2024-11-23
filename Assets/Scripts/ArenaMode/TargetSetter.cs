using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSetter : MonoBehaviour
{
    public GameObject target;
    public string nameTarget;

    void Start()
    {
        Invoke("SetTarget", 1f);
    }

    private void SetTarget()
    {
        target = GameObjectManager.Instance.GameObjectDictionary[nameTarget];
        //aIDestinationSetter.target = target.transform;
    }
}
