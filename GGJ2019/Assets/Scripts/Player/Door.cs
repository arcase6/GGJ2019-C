using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public override void InteractWith(PlayerController callingPlayer)
    {
        if (!callingPlayer.isHiding)
        {
            callingPlayer.SetHiding(true);
            callingPlayer.SetVisibilty(false); //hiding so not visible
            Vector3 newPosition = new Vector3(transform.position.x, callingPlayer.transform.position.y, callingPlayer.transform.position.z);
            callingPlayer.transform.position = newPosition;
        }
        else if(!callingPlayer.isBusyWithAnimation)
        {
            callingPlayer.SetHiding(false);
            callingPlayer.SetVisibilty(true);
        }
        
    }
}
