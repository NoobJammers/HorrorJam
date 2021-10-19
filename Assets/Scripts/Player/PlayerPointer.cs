using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    bool lastHit = false;
    Interactable lastInteractable;

    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(Vector2.one / 2f);
        if (Physics.Raycast(ray, out hit, 2f, layerMask))
        {
            lastInteractable = hit.transform.GetComponent<Interactable>();
            lastInteractable.EnableOutline();
            lastHit = true;
        }
        else
        {
            if (lastHit)
            {
                lastHit = false;
                lastInteractable.DisableOutline();
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (lastHit)
                lastInteractable.PerformInteractableAction();

        }
    }
}
