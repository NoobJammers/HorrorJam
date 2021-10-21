using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Scene3Manager : SceneManager
{

    /* static public Scene4Manager instance;*/



    /// <summary>
    /// BABY VARIABLES
    /// </summary>
    public GameObject baby;
    public CharacterMover baby_char_mover;
    public CharacterHeadLook baby_head_look;
    public CharacterSwitchAnimation baby_switch_animation;

    public Transform baby_init_position;
    public Transform baby_position_1;
    public Transform baby_position_2;
    public Transform baby_position_3;


    /// <summary>
    /// Wife
    /// </summary>
    /// 
    public GameObject wife;
    public CharacterMover wife_char_mover;
    public CharacterHeadLook wife_head_look;
    public CharacterSwitchAnimation wife_switch_animation;
    public Transform wife_init_position;

    public Transform wife_position_1;
    public Transform wife_position_2;
    public Transform wife_position_3;

    public Transform wife_final_position;

    /// <summary>
    /// Man
    /// </summary>
    public GameObject man;
    public CharacterMover man_char_mover;
    public CharacterHeadLook man_head_look;
    public CharacterSwitchAnimation man_switch_animation;
    public Transform man_init_pos;
    public Transform man_position_1;
    public Transform man_position_2;



    /// <summary>
    /// DemonCrawler
    /// </summary>
    public GameObject demoncrawler_one_off;
    public CharacterSwitchAnimation demoncrawler_one_off_switch_animation;
    [SerializeField] Transform demoncrawler_one_off_finalposition;

    /// <summary>
    /// Doors
    /// </summary>

    public DoorHandler masterBedroomDoor;



    /// <summary>
    /// FURNITURE
    /// </summary>
    public GameObject couch, table;
    public Transform couch_position;
    public Transform table_position;



    /// <summary>
    /// PLAYER
    /// </summary>
    public GameObject playerCamera;


    /// <summary>
    /// DEVIL
    /// </summary>

    public GameObject devil;
    public CharacterMover devil_char_mover;
    public CharacterHeadLook devil_head_look;
    public CharacterSwitchAnimation devil_switch_animation;
    public Transform demon_init_position;
    public Transform demon_baby_position;

    /// <summary>
    /// DEMON SPAWNER
    /// </summary>
    /// 

    DemonSpawner spawner;
    Transform[] spawnerpoints;


    /// <summary>
    /// TV
    /// </summary>

    ///<summary>
    /// WallWriting
    ///</summary>

    ///<summary>
    /// PostProcessingVolume
    ///</summary>

    ///<summary>
    ///lights
    ///</summary>
    ///

    ///Book stuff
    ///
    public PushForceScript bookshelf1;
    public Transform PushForceBookShelf1;
    public Light kidroomdoorlight;
    private bool timetopush = false, checkIfRendering = false;



    private void Awake()
    {
        baby.transform.position = baby_init_position.position;
        // man_char_mover.DisableNavMeshAgent();
        man.transform.position = man_init_pos.position;
        wife.transform.position = wife_init_position.position;
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
        if (checkIfRendering)
        {
            Vector2 pos = Camera.main.WorldToViewportPoint(man.transform.position);

            if ((pos.x > 0f && pos.x < 1f && pos.y > 0f && pos.y < 1f) && (Vector3.Dot(man.transform.forward, playerCamera.transform.forward) < 0f))
            {
                Debug.Log("Yeet");
                checkIfRendering = false;
                StartCoroutine(executeafterntime(2f, () => { DoorClose(); }));
            }
        }
    }

    void DoorOpen()
    {
        man.transform.position = man_position_1.position;
        man.transform.rotation = man_position_1.rotation;
        masterBedroomDoor.OpenDoor(0f, true);
        checkIfRendering = true;
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
        man.transform.position = man_position_2.position;
        man.transform.rotation = man_position_2.rotation;
        wife_switch_animation.switchtoanimation("TerrifiedSingleFrame", 0, 1);
        wife.transform.position = wife_position_1.position;
        wife.transform.rotation = wife_position_1.rotation;
        couch.transform.position = couch_position.position;
        couch.transform.rotation = couch_position.rotation;
        table.transform.position = table_position.position;
        table.transform.rotation = table_position.rotation;
    }
    // IEnumerator DomesticViolence()
    // {
    //     yield return new WaitForSeconds(1f);
    //     man_switch_animation.switchtoanimation("ThrowGlassBottleSingleFrame", 0, 1);
    //     man_char_mover.GoToPoint(man_position_1.position, man_position_1.position);
    //     wife_switch_animation.switchtoanimation("TerrifiedSingleFrame", 0, 1);
    //     wife_char_mover.GoToPoint(wife_position_1.position, wife_position_1.position);
    // }

    public void BottleCollected()
    {
        man_switch_animation.switchtoanimation("ThrowWithoutBottleSingleFrame", 0, 1);
    }


}
