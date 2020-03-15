using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Interactable
{
    public GameEventNew GameClear;
    public GameEventNew OnGameClear;

    public override void InteractWith(PlayerController callingPlayer)
    {
        GetComponent<GoalKai>().InteractWith(callingPlayer);
    }
}
