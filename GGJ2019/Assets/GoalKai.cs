using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKai : MonoBehaviour
{
    public GameEventNew GameClear;

    public void InteractWith(PlayerController callingPlayer)
    {
        GameClear.Raise();
    }
}
