using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Scene1Manager : SceneManager
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
    // public Transform man_position_1;
    // public Transform man_position_2;



    // [Header("Demon Crawler")]
    // public GameObject demoncrawler_one_off;
    // public CharacterSwitchAnimation demoncrawler_one_off_switch_animation;
    // [SerializeField] Transform demoncrawler_one_off_finalposition;



    [Header("Doors")]
    public DoorHandler exitDoor;



    // [Header("Furniture")]
    // public GameObject couch;
    // public GameObject table;
    // public Transform couch_position;
    // public Transform table_position;



    // [Header("Player")]
    // public GameObject playerCamera;


    // [Header("Devil")]
    // public GameObject devil;
    // public CharacterMover devil_char_mover;
    // public CharacterHeadLook devil_head_look;
    // public CharacterSwitchAnimation devil_switch_animation;
    // public Transform demon_init_position;
    // public Transform demon_baby_position;



    // [Header("Demon Spawner")]
    // DemonSpawner spawner;
    // Transform[] spawnerpoints;








    ///<summary>
    /// Misc
    ///</summary>
    private bool checkIfRendering = false;



    private void Awake()
    {
        babyGameObject.transform.position = baby_init_position.position;
        babyGameObject.transform.rotation = baby_init_position.rotation;
        baby_switch_animation.switchtoanimation("BabySittingGroundSingleFrame", 0, 0);

        manGameObject.transform.position = man_init_pos.position;
        manGameObject.transform.rotation = man_init_pos.rotation;
        man_switch_animation.switchtoanimation("Drinking", 0, 0);

        wifeGameObject.transform.position = wife_init_position.position;
        wifeGameObject.transform.rotation = wife_init_position.rotation;
        wife_switch_animation.switchtoanimation("SittingFemale", 0, 0);
    }
    private void OnEnable()
    {
        GeneralEvent += TriggerHandler;
        GeneralInteractionEvents += InteractionEventHandler;
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
