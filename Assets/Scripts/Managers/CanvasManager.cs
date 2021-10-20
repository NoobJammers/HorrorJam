using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    static public CanvasManager instance;

    [Header("Narrative fields")]
    [SerializeField] GameObject narrativeTextPanel;
    public TextMeshProUGUI narrativeText;
    [SerializeField] float textDisplayTime;

    [Header("Misc")]
    public GameObject interactText;
    public GameObject diary;

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


    public void SetText(string textToInsert)
    {
        narrativeText.text = textToInsert;
        narrativeTextPanel.SetActive(true);
        StartCoroutine(DisableText());
    }
    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(textDisplayTime);
        narrativeTextPanel.SetActive(false);

    }
}
