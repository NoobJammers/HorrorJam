using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    static public CanvasManager instance;
    [SerializeField] GameObject interactText, diary;

    private void Awake()
    {
        instance = this;
    }

    public void SetInteractText(bool val)
    {
        if (val)
            interactText.SetActive(true);
        else
            interactText.SetActive(false);
    }


    public void EnableDiary(bool val)
    {
        diary.SetActive(val);
    }




}
