using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
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
    public GameObject baby_DEVILEYES;
    public AudioSource baby_audio_source;

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
    public DoorHandler exitroomdoor;
    public DoorHandler entrydoor;

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
    public GameObject wife_DEVILEYES;

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
    public Transform manfinalposition;
    public GameObject man_DEVILEYES;



    /// <summary>
    /// DEVIL
    /// </summary>

    public GameObject devil;
    public CharacterMover devil_char_mover;
    public CharacterHeadLook devil_head_look;
    public Transform devil_final_pos;

    public CharacterSwitchAnimation devil_switch_animation;
    public Transform demon_init_position;
    public Transform demon_baby_position;
    public Transform Lightningbois;
    public GameObject DevilTrigger;
    public LightningFlicker spotlight1;
    public LightningFlicker spotlight2;
    public LightningFlicker kiddoorlightflickr;
    public LightningFlicker innerroomlightflickr;
    public CharacterSwitchAnimation demon_switch_animation;
    /// <summary>
    /// DEMON SPAWNER
    /// </summary>
    /// 

    public DemonCrawler[] crawlers;
    public GameObject devil_key;


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

    /// <summary>
    /// //misc
    /// </summary>
    /// 
    public Volume volume;
    private ColorAdjustments cad;


    public AudioClip babyLaughing, babyCrying;


    /// <summary>
    /// ///////5th scene
    /// </summary>
    /// 

    public Transform wife_finale_Scene_pos;
    public Transform man_finale_scene_pos;
    public Transform baby_finale_scene_pos;
    public Transform devil_finale_scene_pos;



    public List<SaveMyBabyText> saveMyBabyList;


    private void Start()
    {


    }
    private void OnEnable()
    {
        kidroomdoorlight.gameObject.SetActive(false);

        baby.transform.position = baby_init_position.position;
        baby.transform.rotation = baby_init_position.rotation;
        baby_switch_animation.switchtoanimation("standing", 0, 0);
        man.transform.position = maninitpos.position;
        devil.transform.position = devil_final_pos.position + Vector3.up * 10;
        wife.transform.position = wife_position_1.position;
        wife.transform.rotation = wife_position_1.rotation;
        wife_switch_animation.switchtoanimation("womandead", 0, 1);
        kidsRoomDoor.CanOpen = false;
        wiferoomdoor.CanOpen = false;
        demon_switch_animation.animator.enabled = false;
        RenderSettings.ambientLight = new Color(0.15f, 0.15f, 0.15f, 0);
        GeneralEvent += TriggerHandler;
        GeneralInteractionEvents += InteractionEventHandler;
        entrydoor.CanOpen = true;
        baby.transform.GetComponent<NavMeshAgent>().enabled = true;
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
            StartCoroutine(executeafterntime(0.7f, () => { AudioManager.instance.PlaySFX(AudioManager.instance.bookShelfFall); }
            ));

            kidroomdoorlight.gameObject.SetActive(true);
            kidsRoomDoor.OpenDoor(1f, true);
            StartCoroutine(executeafterntime(1, () => { StartMirrorScene(); }));
            kidsRoomDoor.doorOpened += (bool canopen) =>
            {
                if (canopen)
                {
                    DOTween.Kill(wife.transform);
                    baby.transform.GetComponent<NavMeshAgent>().enabled = false;
                    wife.transform.position = wife_final_position.position;
                    wife.transform.forward = wife_final_position.transform.forward;
                    wife_switch_animation.switchtoanimation("ghost", 0, 1);
                    AudioManager.instance.PlaySFX(AudioManager.instance.jumpScare);

                    StartCoroutine(executeafterntime(0.3f, () => { wife_switch_animation.animator.enabled = false; }
                  ));
                    man.transform.position = manfinalposition.position;
                    man.transform.forward = manfinalposition.transform.forward;
                    man_switch_animation.switchtoanimation("standing", 0, 1);
                    man_switch_animation.gameObject.transform.position += Vector3.up * 0.5f;
                    StartCoroutine(executeafterntime(0.3f, () => { man_switch_animation.animator.enabled = false; }
                 ));
                    baby.transform.position = baby_position_3.transform.position;
                    baby.transform.forward = baby_position_3.transform.forward;
                    baby_switch_animation.switchtoanimation("standing", 0, 1);

                    StartCoroutine(executeafterntime(0.3f, () => { baby_switch_animation.animator.enabled = false; }
                    ));
                    /*  baby_switch_animation.animator.enabled = false;*/
                    volume.profile.TryGet<ColorAdjustments>(out cad);
                    wife_head_look.startlookingatplayer();
                    baby_head_look.startlookingatplayer();
                    man_head_look.startlookingatplayer();


                    cad.colorFilter.Override(new Color(1, 0, 0));

                    // wife.transform.Find("DEVILEYES").gameObject.SetActive(true);
                    // man.transform.Find("DEVILEYES").gameObject.SetActive(true);
                    // baby.transform.Find("DEVILEYES").gameObject.SetActive(true);
                    baby_DEVILEYES.SetActive(true);
                    man_DEVILEYES.SetActive(true);
                    wife_DEVILEYES.SetActive(true);



                    man_head_look.startlookingatplayer();
                    wife_head_look.startlookingatplayer();
                    baby_head_look.startlookingatplayer();
                }
            };

        }
        else if (collider.tag == "DevilTrigger")
        {
            Destroy(collider.gameObject);
            AudioManager.instance.PlayBG2(true, AudioManager.instance.horrorViolin);
            devil.transform.position = devil_final_pos.position;
            devil.transform.LookAt(Camera.main.transform);
            devil_switch_animation.switchtoanimation("Raise", 0, 1);
            StartCoroutine(executeafterntime(1.4f, () =>
                 {

                     foreach (DemonCrawler crawler in crawlers)
                     {
                         crawler.gameObject.SetActive(true);
                         crawler.GetComponent<CharacterSwitchAnimation>().switchtoanimation("crawl_fast", 0, 1);
                     }
                 }));

            StartCoroutine(executeafterntime(6, () =>
            {

                AudioManager.instance.PlaySFX(AudioManager.instance.devilAfraid);
                devil.transform.gameObject.SetActive(false);
                devil.transform.position = devil_finale_scene_pos.position;
                devil.transform.forward = devil_finale_scene_pos.forward;
                devil.transform.gameObject.SetActive(true);
                wife.transform.position = wife_finale_Scene_pos.position;
                wife.transform.forward = wife_finale_Scene_pos.forward;

                baby.transform.position = baby_finale_scene_pos.position;
                baby.transform.forward = baby_finale_scene_pos.forward;
                devil_switch_animation.switchtoanimation("seated", 0, 1);

                man_switch_animation.animator.enabled = true;
                man_switch_animation.switchtoanimation("Drinking", 0, 1);
                man_head_look.stoplookingatplayer();
                man.transform.position = man_finale_scene_pos.position;
                man.transform.forward = man_finale_scene_pos.forward;

                wife_switch_animation.animator.enabled = true;
                wife_switch_animation.switchtoanimation("SittingFemale", 0, 1);

                baby_switch_animation.animator.enabled = true;
                baby_switch_animation.switchtoanimation("BabySitting", 0, 1);




                baby_DEVILEYES.SetActive(false);
                wife_DEVILEYES.SetActive(false);
                man_DEVILEYES.SetActive(false);


            }));

        }
        else if (collider.tag == "finalscenetrigger")
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.devilEnd);
            Destroy(collider.gameObject);
            AudioManager.instance.PlayBG2(false, null);
            exitroomdoor.CloseDoor(0.5f, false);
            cad.colorFilter.Override(new Color(1f, 1f, 1f));
            StartCoroutine(executeafterntime(50, () =>
            {
                devil_switch_animation.switchtoanimation("sit_clap", 0, 1);
                StartCoroutine(executeafterntime(0.6f, () => AudioManager.instance.PlaySFX(AudioManager.instance.singleClap)));
                StartCoroutine(executeafterntime(1f, () =>
                {
                    cad.colorFilter.Override(new Color(0, 0, 0));
                    AudioManager.instance.PlaySFX(AudioManager.instance.devilBeginning);

                }));
            }));
        }
        else if (collider.tag == "EnterHouseTrigger")
        {
            entrydoor.CloseDoor(0.5f, false);
            scenedriver.scenemanagers[2].transform.parent.gameObject.SetActive(false);
            Destroy(collider.gameObject);
        }
        //TODO: WHEN FIRST CROSSED THE THRESHOLD OF THE 4TH house TRIGGER
        //--> DOOR CLOSED
        //init stuff

    }

    public void InteractionEventHandler(string event1)
    {
        if (event1 == "Pot")
        {
            CanvasManager.instance.EnableKey(true);
            AudioManager.instance.PlaySFX(AudioManager.instance.keyCollected);
        }
        else if (event1 == "EndKey")
        {
            DOTween.Kill(wife.transform);
            timetopush = true;
            kidsRoomDoor.CanOpen = true;
            wife.transform.position = wife_final_position.position + Vector3.up * 10;
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
        else if (event1 == "DevilKey")
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.keyCollected);
            devil_key.SetActive(false);
            DevilTrigger.SetActive(true);
            exitroomdoor.CanOpen = true;
            exitroomdoor.doorOpened += (canopen) =>
            {
                if (canopen)
                {

                }
            };

        }
    }
    public void StartMirrorScene()
    {

        baby_char_mover.reachedDestination += Kidnap;

        baby_char_mover.GoToPoint(baby_position_1.position, baby_position_2.position, 1.2f);
        baby_audio_source.clip = babyLaughing;
        baby_audio_source.Play();

        /*      MoveCharacterToPosition.Invoke(enterRoomStartPoint.position, kidbed.position);
              ManLookAt.Invoke(Camera.main.transform);*/

    }
    public void Kidnap()
    {
        baby_audio_source.Stop();
        baby_audio_source.clip = babyCrying;
        baby_audio_source.Play();
        demon_switch_animation.animator.enabled = true;
        baby_switch_animation.switchtoanimation("sweep", 0, 1.3f);

        demon_switch_animation.switchtoanimation("kidnap", 0, 1.2f);

        baby_char_mover.reachedDestination -= Kidnap;
        StartCoroutine(executeafterntime(1f, () =>
        {
            kidsRoomDoor.CloseDoor(0.5f, false);
            StartCoroutine(executeafterntime(0.5f, () =>
            {
                baby_audio_source.Stop();
                kidroomdoorlight.gameObject.SetActive(false);
                Destroy(demoncrawler_one_off.gameObject);
            }));
            StartCoroutine(executeafterntime(2f, () =>
            {


                AudioManager.instance.PlayBG2(true, AudioManager.instance.thunder);
                spotlight1.startflickering(); spotlight2.startflickering(); innerroomlightflickr.startflickering(); RenderSettings.ambientLight = new Color(0.107f, 0.107f, 0.107f, 0.107f);
                wife.transform.position = wife_position_2.position;
                wife.transform.forward = wife_position_2.forward;
                wife_switch_animation.switchtoanimation("ghost", 0, 0);
                StartCoroutine(executeafterntime(7.5f, () => { wiferoomdoor.OpenDoor(0.5f, true); wiferoomdoor.CanOpen = true; }));
                wife.transform.DOLocalMoveZ(wife_position_3.position.z, 15).SetEase(Ease.InOutSine).OnComplete(() =>
                {

                    wife.transform.DOLocalRotate(Vector3.up * 0, 4).OnComplete(() =>
                    {
                        wife_switch_animation.switchtoanimation("ghost_point", 0, 1f);
                        foreach (SaveMyBabyText child in saveMyBabyList)
                            child.DisplaySaveText();

                        StartCoroutine(executeafterntime(3f, () =>
                        {
                            foreach (SaveMyBabyText child in saveMyBabyList)
                                child.StopSaveText();
                        }));

                    });

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
        if (g.tag == "MainRoomHandle")
        {
            if (wiferoomdoor.CanOpen)
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
        if (g.tag == "ExitDoorHandle")
        {
            if (exitroomdoor.CanOpen)
                CanvasManager.instance.SetInteractTextValue("Open Door");
            else
                CanvasManager.instance.SetInteractTextValue("Door Locked");
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
