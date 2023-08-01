using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boosters/Boot")]

public class BootsBooster : Booster
{
    public override void OnAdded(BoosterContainer container)
    {
        if (container.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.JumpPower *= 2.5f;

        }  
    }

    public override void OnRemoved(BoosterContainer container)
    {
        if (container.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.JumpPower /= 2.5f;
        }
    }

}
