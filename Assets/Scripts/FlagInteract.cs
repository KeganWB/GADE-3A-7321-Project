using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagInteract : Interactable
{
    public string _flagColor; 

    public override void Interact()
    {
        if (_flagColor == "Blue" )
        {
            GameManager.Instance.PlayerPickedUpBlueFlag(gameObject);
        }
        else if (_flagColor == "Red")
        {
            //Reset the red flag to its spawn point
            transform.position = GameManager.Instance._redFlagSpawnPoint.position;
        }
    }
}