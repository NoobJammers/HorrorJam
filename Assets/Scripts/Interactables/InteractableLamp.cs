using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLamp : Interactable
{
    // [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        base.PerformInteractableAction();
        SceneManager.activeSceneManager.GeneralInteractionEvents("LampFixed");

    }
}
