using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveWhenDeadPlayer : MonoBehaviour
{
    private void OnEnable()
    {
        DeathPlayer.onDeath += StopMove;
        BtnRevive.onRevive += ContinueMove;
    }

    private void OnDisable()
    {
        DeathPlayer.onDeath -= StopMove;
        BtnRevive.onRevive -= ContinueMove;
    }

    public void StopMove()
    {
        //aipath.canMove = false;
    }

    public void ContinueMove()
    {
        //aipath.canMove = true;
    }
}
