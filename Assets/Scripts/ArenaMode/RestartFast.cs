using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFast : MonoBehaviour
{
    public delegate void RestartAction();
    public static event RestartAction onRestart;

    public static void Restart()
    {
        if(onRestart != null)
        {
            onRestart();
            Shooter.temp = false;
            Shooter.canShoot = true;
        }
    }
}
