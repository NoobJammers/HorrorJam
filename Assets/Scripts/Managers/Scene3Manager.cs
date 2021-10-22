using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Scene3Manager : SceneManager
{

    /* static public Scene4Manager instance;*/



    [Header("Baby")]
    public GameObject babyGameObject;
    public CharacterMover baby_char_mover;
    public CharacterHeadLook baby_head_look;
    public CharacterSwitchAnimation baby_switch_animation;

    public Transform baby_init_position;
    public Transform baby_position_1;


    [Header("Wife")]
    public GameObject wifeGameObject;
    public CharacterMover wife_char_mover;
    public CharacterHeadLook wife_head_look;
    public CharacterSwitchAnimation wife_switch_animation;
    public Transform wife_init_position;

    public Transform wife_position_1;
    public Transform wife_position_2;




    [Header("Man")]
    public GameObject manGameObject;
    public CharacterMover man_char_mover;
    public CharacterHeadLook man_head_look;
    public CharacterSwitchAnimation man_switch_animation;
    public Transform man_init_pos;
    public Transform man_position_1;
    public Transform man_position_2;



    // [Header("Demon Crawler")]
    // public GameObject demoncrawler_one_off;
    // public CharacterSwitchAnimation demoncrawler_one_off_switch_animation;
    // [SerializeField] Transform demoncrawler_one_off_finalposition;



    [Header("Doors")]
    public DoorHandler exitDoor;
    public DoorHandler masterBedroomDoor;



    [Header("Furniture")]
    public GameObject couch;
    public GameObject table;
    public Transform couch_position;
    public Transform table_position;



    [Header("Player")]
    public GameObject playerCamera;


    [Header("Devil")]
    public GameObject devilGameObject;
    public CharacterMover devil_char_mover;
    public CharacterHeadLook devil_head_look;
    public CharacterSwitchAnimation devil_switch_animation;
    public Transform devil_init_position;
    public Transform devil_position_1;



    // [Header("Demon Spawner")]
    // DemonSpawner spawner;
    // Transform[] spawnerpoints;



    [Header("Walls to write upon")]
    public List<WallText> walltextList;



    [Header("Lights")]
    public List<Light> lights;

    [Header("Misc")]
    public GameObject blood;
    public GameObject glass, bottle;
    private bool checkIfRenderingMan = false, checkIfRenderingDevil = false;



    private void Awake()
    {

    }
    private void OnEnable()
    {
        babyGameObject.transform.position = baby_init_position.position;
        // man_char_mover.DisableNavMeshAgent();
        manGameObject.transform.position = man_init_pos.position;
        wifeGameObject.transform.position = wife_init_position.position;
        devilGameObject.transform.position = devil_init_position.position;
        GeneralEvent += TriggerHandler;
        GeneralInteractionEvents += InteractionEventHandler;
    }

    /// <summary>
    /// All individually occuring custom events, don't need a separate system.
    /// </summary>
    public void TriggerHandler(Collider collider)
    {
        // if (collider.tag == "MirrorTrigger")
        // {
        //     Destroy(collider.gameObject);
        //     bookshelf1.push(PushForceBookShelf1.forward, 40, PushForceBookShelf1.position);
        //     kidroomdoorlight.gameObject.SetActive(true);
        //     kidsRoomDoor.OpenDoor(1f, true);
        //     StartCoroutine(executeafterntime(1, () => { StartMirrorScene(); }));


        // }
        // if (collider.tag == "PickUpTrigger")
        // {
        //     Destroy(collider.gameObject);
        //     /* StartBabySnatchedScene();*/
        // }
        //TODO: WHEN FIRST CROSSED THE THRESHOLD OF THE 4TH house TRIGGER
        //--> DOOR CLOSED
        //init stuff

    }

    public void InteractionEventHandler(string event1)
    {

        if (event1 == "ReadDiary")
        {
            CanvasManager.instance.EnableDiary(true);
            DoorOpen();
        }
        else if (event1 == "EndDiary")
        {

        }
        else if (event1 == "Bottle")
            BottleCollected();
    }



    IEnumerator executeafterntime(float n, Action a)
    {
        yield return new WaitForSeconds(n);
        a.Invoke();
    }

    public override void WhatIsBeingHighlighted(GameObject g)
    {
        base.WhatIsBeingHighlighted(g);
        // if (g.tag == "KidDoorHandle")
        // {
        //     if (kidsRoomDoor.CanOpen)
        //         CanvasManager.instance.SetInteractTextValue("Open Door");
        //     else
        //         CanvasManager.instance.SetInteractTextValue("Door Locked");

        // }
        // if (g.name == "BookShelf")

        // {
        //     if (timetopush)
        //     {
        //         CanvasManager.instance.SetInteractTextValue("Push");
        //     }
        //     else
        //     {
        //         CanvasManager.instance.SetInteractTextValue("");
        //     }
        // }
    }
    private void OnDisable()
    {
        GeneralEvent -= TriggerHandler;
        GeneralInteractionEvents -= InteractionEventHandler;
    }


    private void Update()
    {
        if (checkIfRenderingMan)
        {
            Vector2 pos = Camera.main.WorldToViewportPoint(manGameObject.transform.position);

            if ((pos.x > 0f && pos.x < 1f && pos.y > 0f && pos.y < 1f) && (Vector3.Dot(manGameObject.transform.forward, playerCamera.transform.forward) < 0f))
            {
                checkIfRenderingMan = false;
                StartCoroutine(executeafterntime(2f, () => { DoorClose(); }));
            }
        }

        if (checkIfRenderingDevil)
        {
            Vector2 pos = Camera.main.WorldToViewportPoint(devilGameObject.transform.position);

            if ((pos.x > 0f && pos.x < 1f && pos.y > 0f && pos.y < 1f) && (Vector3.Dot(devilGameObject.transform.forward, playerCamera.transform.forward) < 0f))
            {
                checkIfRenderingDevil = false;
                StartCoroutine(executeafterntime(0.5f, () => { DevilClap(); }));
            }
        }

    }

    void DoorOpen()
    {
        manGameObject.transform.position = man_position_1.position;
        manGameObject.transform.rotation = man_position_1.rotation;
        masterBedroomDoor.OpenDoor(0f, true);
        checkIfRenderingMan = true;
    }

    void DoorClose()
    {
        masterBedroomDoor.CloseDoor(0.5f);
        StartCoroutine(executeafterntime(0.5f, () => { DomesticViolence(); }));
        // StartCoroutine(DomesticViolence());
    }

    void DomesticViolence()
    {
        man_switch_animation.switchtoanimation("ThrowGlassBottleSingleFrame", 0, 1);
        manGameObject.transform.position = man_position_2.position;
        manGameObject.transform.rotation = man_position_2.rotation;
        wife_switch_animation.switchtoanimation("TerrifiedSingleFrame", 0, 1);
        wifeGameObject.transform.position = wife_position_1.position;
        wifeGameObject.transform.rotation = wife_position_1.rotation;
        couch.transform.position = couch_position.position;
        couch.transform.rotation = couch_position.rotation;
        table.transform.position = table_position.position;
        table.transform.rotation = table_position.rotation;
        glass.SetActive(false);
        bottle.SetActive(false);
    }

    public void BottleCollected()
    {
        man_switch_animation.switchtoanimation("ThrowWithoutBottleSingleFrame", 0, 1f);
        babyGameObject.transform.position = baby_position_1.position;
        babyGameObject.transform.rotation = baby_position_1.rotation;
        baby_switch_animation.switchtoanimation("BabyWallPeak", 0, 1f);
        devilGameObject.transform.position = devil_position_1.position;
        devilGameObject.transform.rotation = devil_position_1.rotation;
        devil_switch_animation.switchtoanimation("StandingClapIdle", 0, 1f);

        checkIfRenderingDevil = true;

        foreach (WallText child in walltextList)
        {
            child.DisplayBloodText();
        }

    }




    public void DevilClap()
    {
        devil_switch_animation.switchtoanimation("StandingClap", 0, 1f);
        StartCoroutine(executeafterntime(2f, () => { DevilDisappear(); }));
    }
    public void DevilDisappear()
    {

        SetAllLights(false);

        //Stop blood text
        foreach (WallText child in walltextList)
        {
            child.StopBloodText();
            exitDoor.CanOpen = true;
        }

        devilGameObject.transform.position = devil_init_position.position;
        manGameObject.transform.position = man_init_pos.position;
        wife_switch_animation.switchtoanimation("womandead", 0, 1f);
        wifeGameObject.transform.position = wife_position_2.position;
        blood.SetActive(true);
        StartCoroutine(executeafterntime(2f, () => { SetAllLights(true); }));
    }
    public void SetAllLights(bool val)
    {
        foreach (Light child in lights)
            child.enabled = val;
    }

    // private void Start()
    // {
    //     BottleCollected();
    // }

}
