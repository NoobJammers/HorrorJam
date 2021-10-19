using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDiary : Interactable
{
    // [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        base.PerformInteractableAction();
        Scene4Manager.instance.SetDiary(true);

    }
}
