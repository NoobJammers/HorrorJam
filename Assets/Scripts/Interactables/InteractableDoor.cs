using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        base.PerformInteractableAction();
        doorHandler.OpenDoor(1f);
    }
}
