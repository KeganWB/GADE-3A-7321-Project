using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagInteract : Interactable
{
    public string flagColor; 

    protected override void Interact()
    {
        if (flagColor == "Blue")
        {
            GameManager.Instance.PlayerPickedUpBlueFlag(gameObject);
        }
        else if (flagColor == "Red")
        {
            GameManager.Instance.EnemyReturnedRedFlagAtBase();
        }
    }
}


