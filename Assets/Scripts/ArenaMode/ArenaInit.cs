using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaInit : MonoBehaviour
{
    public ArenaLoader arenaLoader;
    void Start()
    {
        arenaLoader.loadArena();
    }

}
