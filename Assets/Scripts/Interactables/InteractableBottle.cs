using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBottle : Interactable
{
    // [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        base.PerformInteractableAction();
        SceneDriver.activeSceneManager.GeneralInteractionEvents?.Invoke("Bottle");

    }
}
