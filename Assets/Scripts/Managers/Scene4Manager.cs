using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Scene4Manager : MonoBehaviour
{

    static public Scene4Manager instance;


    public System.Action<Collider> GeneralEvent = (Collider collider) =>
    {

    };
    public System.Action<string> GeneralInteractionEvents = (string event1) => { };
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
    public Light kidroomdoorlight;
    private void Awake()
    {
        instance = this;
        kidroomdoorlight.gameObject.SetActive(false);
        baby.transform.position = baby_init_position.position;
        man.transform.position = maninitpos.position;

        GeneralEvent += (Collider collider) =>
          {

              if (collider.tag == "MirrorTrigger")
              {
                  Destroy(collider.gameObject);
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
          };
        GeneralInteractionEvents += (string event1) =>
        {
            if (event1 == "ReadDiary")
                SetDiary();

            else if (event1 == "EndDiary")
                DomesticViolence();

            else if (event1 == "Bottle")
                BottleCollected();
        };

    }

    /// <summary>
    /// All individually occuring custom events, don't need a separate system.
    /// </summary>

    public void StartMirrorScene()
    {

        baby_char_mover.reachedDestination += Kidnap;

        baby_char_mover.GoToPoint(baby_position_1.position, baby_position_2.position, 1.3f);


        /*      MoveCharacterToPosition.Invoke(enterRoomStartPoint.position, kidbed.position);
              ManLookAt.Invoke(Camera.main.transform);*/

    }
    public void Kidnap()
    {
        baby_switch_animation.switchtoanimation("sweep", 0, 1);

        devil_switch_animation.switchtoanimation("kidnap", 0, 1);

        baby_char_mover.reachedDestination -= Kidnap;
        StartCoroutine(executeafterntime(2.15f, () => { kidsRoomDoor.CloseDoor(0.5f); }));
    }
    public void StartBabySnatchedScene()
    {
        /*        BabyChangeAnimation.Invoke("PickUp", 0);*/

    }

    IEnumerator executeafterntime(float n, Action a)
    {
        yield return new WaitForSeconds(n);
        a.Invoke();
    }

    public void SetDiary()
    {
        CanvasManager.instance.EnableDiary(true);
    }


    public void DomesticViolence()
    {
        man_switch_animation.switchtoanimation("ThrowGlassBottleSingleFrame", 0, 1);
        man_char_mover.GoToPoint(man_position_1.position, man_position_1.position);
        wife_switch_animation.switchtoanimation("TerrifiedSingleFrame", 0, 1);
        wife_char_mover.GoToPoint(wife_position_1.position, wife_position_1.position);
    }

    public void BottleCollected()
    {
        man_switch_animation.switchtoanimation("ThrowWithoutBottleSingleFrame", 0, 1);
    }

}
