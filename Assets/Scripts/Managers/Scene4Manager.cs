using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.AI;
using DG.Tweening;
public class Scene4Manager : SceneManager
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
    /// DemonCrawler
    /// </summary>
    public GameObject demoncrawler_one_off;
    public CharacterSwitchAnimation demoncrawler_one_off_switch_animation;
    [SerializeField] Transform demoncrawler_one_off_finalposition;

    /// <summary>
    /// Doors
    /// </summary>

    public DoorHandler kidsRoomDoor;
    public DoorHandler wiferoomdoor;


    /// <summary>
    /// Wife
    /// </summary>
    /// 
    public GameObject wife;
    public CharacterMover wife_char_mover;
    public CharacterHeadLook wife_head_look;
    public CharacterSwitchAnimation wife_switch_animation;
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
    public Transform man_position_1;


    public float[] man_shoot_timestamps;
    public Transform maninitpos;




    /// <summary>
    /// DEVIL
    /// </summary>

    public GameObject devil;
    public CharacterMover devil_char_mover;
    public CharacterHeadLook devil_head_look;
    public CharacterSwitchAnimation devil_switch_animation;
    public Transform demon_init_position;
    public Transform demon_baby_position;
    public Transform Lightningbois;
    public LightningFlicker spotlight1;
    public LightningFlicker spotlight2;
    public LightningFlicker kiddoorlightflickr;
    public LightningFlicker innerroomlightflickr;
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
    private bool timetopush = false;
    private void Awake()
    {




    }
    private void OnEnable()
    {
        kidroomdoorlight.gameObject.SetActive(false);
        baby.transform.GetComponent<NavMeshAgent>().enabled = true;
        baby.transform.position = baby_init_position.position;
        baby.transform.rotation = baby_init_position.rotation;
        baby_switch_animation.switchtoanimation("standing", 0, 0);
        man.transform.position = maninitpos.position;
        wife.transform.position = wife_position_1.position;
        wife.transform.rotation = wife_position_1.rotation;
        wife_switch_animation.switchtoanimation("womandead", 0, 1);
        kidsRoomDoor.CanOpen = false;
        wiferoomdoor.CanOpen = false;
        RenderSettings.ambientLight = new Color(0.13f, 0.13f, 0.13f, 0);
        GeneralEvent += TriggerHandler;
        GeneralInteractionEvents += InteractionEventHandler;
    }

    /// <summary>
    /// All individually occuring custom events, don't need a separate system.
    /// </summary>
    public void TriggerHandler(Collider collider)
    {


        if (collider.tag == "MirrorTrigger")
        {

            Destroy(collider.gameObject);
            bookshelf1.push(PushForceBookShelf1.forward, 40, PushForceBookShelf1.position);
            kidroomdoorlight.gameObject.SetActive(true);
            kidsRoomDoor.OpenDoor(1f, true);
            StartCoroutine(executeafterntime(1, () => { StartMirrorScene(); }));


        }
        if (collider.tag == "PickUpTrigger")
        {
            Destroy(collider.gameObject);
            /* StartBabySnatchedScene();*/
        }
        //TODO: WHEN FIRST CROSSED THE THRESHOLD OF THE 4TH house TRIGGER
        //--> DOOR CLOSED
        //init stuff

    }

    public void InteractionEventHandler(string event1)
    {
        if (event1 == "Pot")
            CanvasManager.instance.EnableKey(true);
        else if (event1 == "EndKey")
        {
            timetopush = true;
            kidsRoomDoor.CanOpen = true;
            wife.transform.position = wife_final_position.position;
            wife.transform.forward = wife_final_position.forward;
            kidroomdoorlight.gameObject.SetActive(true);
        }
        else if (event1 == "Shelf")
        {
            if (timetopush)
            {
                bookshelf1.push(bookshelf1.transform.right + bookshelf1.transform.forward, 1000, bookshelf1.transform.position);


            }
            else
            {
                CanvasManager.instance.SetInteractTextValue("");
            }
        }
    }
    public void StartMirrorScene()
    {

        baby_char_mover.reachedDestination += Kidnap;

        baby_char_mover.GoToPoint(baby_position_1.position, baby_position_2.position, 1.2f);


        /*      MoveCharacterToPosition.Invoke(enterRoomStartPoint.position, kidbed.position);
              ManLookAt.Invoke(Camera.main.transform);*/

    }
    public void Kidnap()
    {
        baby_switch_animation.switchtoanimation("sweep", 0, 1.3f);

        devil_switch_animation.switchtoanimation("kidnap", 0, 1.2f);

        baby_char_mover.reachedDestination -= Kidnap;
        StartCoroutine(executeafterntime(1f, () =>
        {
            kidsRoomDoor.CloseDoor(0.5f, false);
            StartCoroutine(executeafterntime(0.5f, () => { kidroomdoorlight.gameObject.SetActive(false); }));
            StartCoroutine(executeafterntime(2f, () =>
            {



                spotlight1.startflickering(); spotlight2.startflickering(); innerroomlightflickr.startflickering(); RenderSettings.ambientLight = new Color(0.107f, 0.107f, 0.107f, 0.107f);
                wife.transform.position = wife_position_2.position;
                wife.transform.forward = wife_position_2.forward;
                wife_switch_animation.switchtoanimation("ghost", 0, 0);
                wife.transform.DOLocalMoveZ(wife_position_3.position.z, 15).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    wife.transform.DOLocalRotate(Vector3.up * 0, 4).OnComplete(() => { wife_switch_animation.switchtoanimation("ghost_point", 0, 1f); });

                });
            }));
        }));

    }


    IEnumerator executeafterntime(float n, Action a)
    {
        yield return new WaitForSeconds(n);
        a.Invoke();
    }

    public override void WhatIsBeingHighlighted(GameObject g)
    {
        base.WhatIsBeingHighlighted(g);
        if (g.tag == "KidDoorHandle")
        {
            if (kidsRoomDoor.CanOpen)
                CanvasManager.instance.SetInteractTextValue("Open Door");
            else
                CanvasManager.instance.SetInteractTextValue("Door Locked");

        }
        if (g.name == "BookShelf")

        {
            if (timetopush)
            {
                CanvasManager.instance.SetInteractTextValue("Push");
            }
            else
            {
                CanvasManager.instance.SetInteractTextValue("");
            }
        }
    }
    private void OnDisable()
    {
        GeneralEvent -= TriggerHandler;
        GeneralInteractionEvents -= InteractionEventHandler;
    }


    /*    public void DomesticViolence()
        {
            man_switch_animation.switchtoanimation("ThrowGlassBottleSingleFrame", 0, 1);
            man_char_mover.GoToPoint(man_position_1.position, man_position_1.position);
            wife_switch_animation.switchtoanimation("TerrifiedSingleFrame", 0, 1);
            wife_char_mover.GoToPoint(wife_position_1.position, wife_position_1.position);
        }

        public void BottleCollected()
        {
            man_switch_animation.switchtoanimation("ThrowWithoutBottleSingleFrame", 0, 1);
        }*/

}
