using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDevilKey : Interactable
{
    // [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        base.PerformInteractableAction();
        SceneDriver.activeSceneManager.GeneralInteractionEvents?.Invoke("DevilKey");

    }
}
