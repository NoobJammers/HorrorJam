using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using DG.Tweening;
public class Scene2Manager : SceneManager
{

    /* static public Scene4Manager instance;*/
    private bool otherhouseactive;
    public GameObject alllights;
    public GameObject tvspot1;
    public GameObject tvspot2;
    public GameObject drinkglass;

    public Material sad_sky_box;
    [Header("Baby")]
    public GameObject babyGameObject;
    public CharacterMover baby_char_mover;
    public CharacterHeadLook baby_head_look;
    public CharacterSwitchAnimation baby_switch_animation;

    public Transform baby_init_position;

    public Transform baby_DEVILEYES;
    // public Transform baby_position_1;
    // public Transform baby_position_2;
    // public Transform baby_position_3;


    [Header("Wife")]
    public GameObject wifeGameObject;
    public CharacterMover wife_char_mover;
    public CharacterHeadLook wife_head_look;
    public CharacterSwitchAnimation wife_switch_animation;
    public Transform wife_init_position;
    public Transform WIFE_DEVILEYES;

    // public Transform wife_position_1;
    // public Transform wife_position_2;
    // public Transform wife_position_3;

    // public Transform wife_final_position;



    [Header("Man")]
    public GameObject manGameObject;
    public CharacterMover man_char_mover;
    public CharacterHeadLook man_head_look;
    public CharacterSwitchAnimation man_switch_animation;
    public Transform man_init_pos;
    public Transform MAN_DEVILEYES;
    public SkinnedMeshRenderer manrend;

    [Header("Lights")]
    public Light hallLamp;
    public List<Light> remainingLights;


    [Header("Doors")]
    public DoorHandler exitDoor;
    public DoorHandler entrydoor;

    [Header("Audio Scources")]
    public AudioSource hallLampAS;



    [Header("Misc")]
    public GameObject bulb;
    public Interactable lampInteractable;
    public LightningFlicker hallLampLightningFlicker;
    private bool checkIfRendering = false;
    bool fixedBulb = false;



    private void Awake()
    {

    }

    private void Update()
    {

    }



    private void OnEnable()
    {
        GeneralEvent += TriggerHandler;
        GeneralInteractionEvents += InteractionEventHandler;
        babyGameObject.transform.position = baby_init_position.position;
        babyGameObject.transform.rotation = baby_init_position.rotation;
        baby_switch_animation.switchtoanimation("BabySittingGroundSingleFrame", 0, 0);

        manGameObject.transform.position = man_init_pos.position;
        manGameObject.transform.rotation = man_init_pos.rotation;
        man_switch_animation.switchtoanimation("Drinking", 0, 0);

        wifeGameObject.transform.position = wife_init_position.position;
        wifeGameObject.transform.rotation = wife_init_position.rotation;
        wife_switch_animation.switchtoanimation("SittingFemale", 0, 0);

        entrydoor.CanOpen = true;
        hallLampLightningFlicker.startflickering();
    }

    /// <summary>
    /// All individually occuring custom events, don't need a separate system.
    /// </summary>
    public void TriggerHandler(Collider collider)
    {
        if (collider.tag == "BulbTrigger")
        {
            Destroy(collider.gameObject);
            bulb.SetActive(true);
            bulb.transform.DOMoveX(bulb.transform.position.x - 1.7f, 2f);
            bulb.transform.DOLocalRotate(Vector3.right * (bulb.transform.eulerAngles.x + 720f), 2f);
        }
        if (collider.tag == "ExitHouseTrigger")
        {
            scenedriver.switchScene();
            exitDoor.CloseDoor(0.5f, false);
            Destroy(collider.gameObject);
        }
        if (collider.tag == "EnterHouseTrigger")
        {
            entrydoor.CloseDoor(0.5f, false);
            scenedriver.scenemanagers[0].transform.parent.gameObject.SetActive(false);
            Destroy(collider.gameObject);
        }
        if (collider.tag == "AboutToExitTrigger")
        {
            if (otherhouseactive)
            {
                scenedriver.scenemanagers[2].transform.parent.gameObject.SetActive(false);
                otherhouseactive = false;
            }
            else
            {
                scenedriver.scenemanagers[2].transform.parent.gameObject.SetActive(true);
                otherhouseactive = true;
            }
        }
    }

    public void InteractionEventHandler(string event1)
    {

        if (event1 == "LampCollected")
        {
            CanvasManager.instance.EnableBulb(true);
            lampInteractable.isInteractable = true;
            AudioManager.instance.PlaySFX(AudioManager.instance.bulbCollected);
        }
        else if (event1 == "LampFixed")
        {
            float intensity = hallLampLightningFlicker.original_intensity;
            hallLamp.intensity = intensity;
            hallLampAS.enabled = false;
            AudioManager.instance.PlaySFX(AudioManager.instance.bulbCollected);
            Destroy(hallLampLightningFlicker);



            //Validate
            //Blackout
            exitDoor.CanOpen = true;
            StartCoroutine(checkforvisibility(() =>
            {

                man_switch_animation.animator.enabled = false;
                wife_switch_animation.animator.enabled = false;
                baby_switch_animation.animator.enabled = false;
                AudioManager.instance.PlaySFX(AudioManager.instance.jumpScare);

                man_head_look.startlookingatplayer();
                wife_head_look.startlookingatplayer();
                baby_head_look.startlookingatplayer();

                MAN_DEVILEYES.gameObject.SetActive(true);
                WIFE_DEVILEYES.gameObject.SetActive(true);
                baby_DEVILEYES.gameObject.SetActive(true);
                StartCoroutine(executeafterntime(1, () =>
                {
                    alllights.SetActive(false);
                    tvspot1.SetActive(false);
                    tvspot2.SetActive(false);
                }));

                StartCoroutine(executeafterntime(2.5f, () =>
                {

                    manGameObject.SetActive(false);
                    wifeGameObject.SetActive(false);
                    babyGameObject.SetActive(false);

                    MAN_DEVILEYES.gameObject.SetActive(false);
                    WIFE_DEVILEYES.gameObject.SetActive(false);
                    baby_DEVILEYES.gameObject.SetActive(false);


                    drinkglass.SetActive(false);
                    alllights.SetActive(true);
                    tvspot1.SetActive(true);
                    tvspot2.SetActive(true);



                }));
            }));

        }
    }

    IEnumerator checkforvisibility(Action a)
    {
        while (true)
        {
            if (CheckVisibility())
            {
                a.Invoke();
                yield break;
            }
            yield return null;
        }
    }
    public bool CheckVisibility()
    {
        //Check Visibility

        Vector2 screenPos = Camera.main.WorldToScreenPoint(manGameObject.transform.position);
        bool onScreen = screenPos.x > 0f && screenPos.x < Screen.width && screenPos.y > 0f && screenPos.y < Screen.height;

        if (onScreen && manrend.isVisible)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator executeafterntime(float n, Action a)
    {
        yield return new WaitForSeconds(n);
        a.Invoke();
    }

    public override void WhatIsBeingHighlighted(GameObject g)
    {
        base.WhatIsBeingHighlighted(g);

    }
    private void OnDisable()
    {
        man_head_look.stoplookingatplayer();
        wife_head_look.stoplookingatplayer();
        baby_head_look.stoplookingatplayer();

        man_switch_animation.animator.enabled = true;
        wife_switch_animation.animator.enabled = true;
        baby_switch_animation.animator.enabled = true;

        manGameObject.transform.position += Vector3.up * 5;
        wifeGameObject.transform.position += Vector3.up * 5;
        babyGameObject.transform.position += Vector3.up * 5;

        manGameObject.SetActive(true);
        wifeGameObject.SetActive(true);
        babyGameObject.SetActive(true);
        GeneralEvent -= TriggerHandler;
        GeneralInteractionEvents -= InteractionEventHandler;

        RenderSettings.skybox = sad_sky_box;

    }




}
