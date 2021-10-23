using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Outline outline;
    public bool isInteractable = true;

    public void EnableOutline()
    {
        if (isInteractable)
        {
            outline.OutlineWidth = 6f;
            SceneDriver.activeSceneManager.WhatIsBeingHighlighted(gameObject);
            CanvasManager.instance.SetInteractText(true);
        }
    }

    public void DisableOutline()
    {
        outline.OutlineWidth = 0f;
        CanvasManager.instance.SetInteractTextValue("Interact[E]");
        CanvasManager.instance.SetInteractText(false);


    }

    virtual public void PerformInteractableAction() { }
}
