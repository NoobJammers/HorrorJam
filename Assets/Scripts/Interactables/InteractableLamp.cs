using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLamp : Interactable
{
    // [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        if (isInteractable)
        {
            base.PerformInteractableAction();
            SceneManager.activeSceneManager.GeneralInteractionEvents("LampFixed");
            isInteractable = false;
        }
    }
}
