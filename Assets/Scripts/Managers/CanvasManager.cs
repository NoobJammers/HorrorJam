using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    static public CanvasManager instance;

    [Header("Narrative fields")]
    [SerializeField] GameObject narrativeTextPanel;
    public TextMeshProUGUI narrativeText;
    [SerializeField] float textDisplayTime;

    [Header("Misc")]
    public GameObject startPanel;
    public GameObject endPanel;
    public Image fadeImage;
    public GameObject interactText;
    public GameObject diary;
    public GameObject key;
    public GameObject bulb;
    public Button startButton, exitButton, mainMenuButton;
    float fadeTIme = 1f;
    public RectTransform credits;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ShowCredits();
    }
    public void SetInteractTextValue(string text)
    {
        interactText.GetComponent<TextMeshProUGUI>().text = text;
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

    public void EnableKey(bool val)
    {
        key.SetActive(val);
    }

    public void EnableBulb(bool val)
    {
        bulb.SetActive(val);
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


    public void StartGame()
    {
        startButton.interactable = false;
        exitButton.interactable = false;
        fadeImage.DOFade(0f, 0f);
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1f, fadeTIme).OnComplete(() =>
        {
            startPanel.SetActive(false);
            fadeImage.DOFade(0f, fadeTIme).OnComplete(() =>
            {
                startPanel.gameObject.SetActive(false);
                PlayerController.instance.SetCanMove(true);
                MouseLook.instance.LockCursor(true);
                AudioManager.instance.PlayBG1(true);
                AudioManager.instance.PlaySFX(AudioManager.instance.devilBeginning);

            });
        });
    }


    public void ShowCredits()
    {
        fadeImage.DOFade(0f, 0f);
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1f, fadeTIme).OnComplete(() =>
           {
               endPanel.SetActive(true);
               PlayerController.instance.SetCanMove(false);

               fadeImage.DOFade(0f, fadeTIme).OnComplete(() =>
               {
                   fadeImage.gameObject.SetActive(false);
                   MouseLook.instance.LockCursor(false);
                   credits.DOAnchorPosY(credits.anchoredPosition.y + 1000f, 10f).OnComplete(() => GoToMenu());

               });
           });
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



}
