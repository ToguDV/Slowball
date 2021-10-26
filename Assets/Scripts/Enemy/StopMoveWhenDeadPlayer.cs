using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StopMoveWhenDeadPlayer : MonoBehaviour
{
    public AIPath aipath;
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
        aipath.canMove = false;
    }

    public void ContinueMove()
    {
        aipath.canMove = true;
    }
}
