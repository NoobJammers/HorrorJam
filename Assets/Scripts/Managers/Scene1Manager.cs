using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Scene1Manager : SceneManager
{

    [Header("Baby")]
    public GameObject babyGameObject;
    public CharacterMover baby_char_mover;
    public CharacterHeadLook baby_head_look;
    public CharacterSwitchAnimation baby_switch_animation;

    public Transform baby_init_position;



    [Header("Wife")]
    public GameObject wifeGameObject;
    public CharacterMover wife_char_mover;
    public CharacterHeadLook wife_head_look;
    public CharacterSwitchAnimation wife_switch_animation;
    public Transform wife_init_position;





    [Header("Man")]
    public GameObject manGameObject;
    public CharacterMover man_char_mover;
    public CharacterHeadLook man_head_look;
    public CharacterSwitchAnimation man_switch_animation;
    public Transform man_init_pos;


    [Header("Doors")]
    public DoorHandler exitDoor;


    [Header("Misc")]
    public GameObject whiskyGlass;


    ///<summary>
    /// Misc
    ///</summary>
    private bool checkIfRendering = false;



    private void Awake()
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
        whiskyGlass.SetActive(true);

        wifeGameObject.transform.position = wife_init_position.position;
        wifeGameObject.transform.rotation = wife_init_position.rotation;
        wife_switch_animation.switchtoanimation("SittingFemale", 0, 0);

        exitDoor.CanOpen = true;
    }

    /// <summary>
    /// All individually occuring custom events, don't need a separate system.
    /// </summary>
    public void TriggerHandler(Collider collider)
    {

    }

    public void InteractionEventHandler(string event1)
    {


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
