using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    bool lastHit = false, doOnceDiary = true, doOnceKey = true;
    Interactable lastInteractable;



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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanvasManager.instance.diary.activeInHierarchy)
            {
                CanvasManager.instance.EnableDiary(false);

                if (doOnceDiary)
                {
                    doOnceDiary = false;
                    SceneManager.activeSceneManager.GeneralInteractionEvents?.Invoke("EndDiary");
                }
            }
            else if (CanvasManager.instance.key.activeInHierarchy)
            {
                CanvasManager.instance.EnableKey(false);
                if (doOnceKey)
                {
                    doOnceKey = false;
                    Scene4Manager.activeSceneManager.GeneralInteractionEvents?.Invoke("EndKey");
                }
            }
            else if (CanvasManager.instance.bulb.activeInHierarchy)
            {
                CanvasManager.instance.EnableBulb(false);
            }
        }
    }
}
