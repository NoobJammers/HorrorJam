using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Outline outline;


    public void EnableOutline()
    {
        outline.OutlineWidth = 6f;
        CanvasManager.instance.SetInteractText(true);
    }

    public void DisableOutline()
    {
        outline.OutlineWidth = 0f;
        CanvasManager.instance.SetInteractText(false);


    }

    virtual public void PerformInteractableAction() { }
}
