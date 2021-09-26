using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnReloadArena : MonoBehaviour
{
    public ArenaLoader arenaLoader;

    public void Click()
    {
        arenaLoader.loadArena();
    }
}
