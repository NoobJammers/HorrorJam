using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using DG.Tweening;
public class Scene2Manager : SceneManager
{

    /* static public Scene4Manager instance;*/



    [Header("Baby")]
    public GameObject babyGameObject;
    public CharacterMover baby_char_mover;
    public CharacterHeadLook baby_head_look;
    public CharacterSwitchAnimation baby_switch_animation;

    public Transform baby_init_position;
    // public Transform baby_position_1;
    // public Transform baby_position_2;
    // public Transform baby_position_3;


    [Header("Wife")]
    public GameObject wifeGameObject;
    public CharacterMover wife_char_mover;
    public CharacterHeadLook wife_head_look;
    public CharacterSwitchAnimation wife_switch_animation;
    public Transform wife_init_position;

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


    [Header("Lights")]
    public Light hallLamp;
    public List<Light> remainingLights;


    [Header("Doors")]
    public DoorHandler exitDoor;


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
        if (!fixedBulb)
        {

        }
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
    }

    public void InteractionEventHandler(string event1)
    {

        if (event1 == "LampCollected")
        {
            CanvasManager.instance.EnableBulb(true);
            lampInteractable.isInteractable = true;
        }
        else if (event1 == "LampFixed")
        {
            // hallLampLightningFlicker.stopflickering();
            float intensity = hallLampLightningFlicker.original_intensity;
            // hallLampLightningFlicker.enabled = false;
            Destroy(hallLampLightningFlicker);
            hallLamp.intensity = intensity;
            Debug.Log("Yeet");
            //Do neck snap staring
            //Validate
            //Blackout
            exitDoor.CanOpen = true;
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
        GeneralEvent -= TriggerHandler;
        GeneralInteractionEvents -= InteractionEventHandler;
    }




}
