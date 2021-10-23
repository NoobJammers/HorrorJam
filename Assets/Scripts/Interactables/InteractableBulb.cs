using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBulb : Interactable
{
    // [SerializeField] DoorHandler doorHandler;
    override public void PerformInteractableAction()
    {
        base.PerformInteractableAction();
        SceneDriver.activeSceneManager.GeneralInteractionEvents("LampCollected");
        gameObject.SetActive(false);

    }
}
