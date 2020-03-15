using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatcher : MonoBehaviour
{
    public GameEventNew OnPlayerCatch;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerHeart")
        {
            OnPlayerCatch.Raise();
        }
    }
}
