using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class Scene4Manager : MonoBehaviour
{

    static public Scene4Manager instance;
    [SerializeField]
    GameObject husband, wife, kid;
    [SerializeField] DoorHandler kidsRoomDoor;
    [SerializeField] Transform enterRoomStartPoint;

    public System.Action<Collider> GeneralEvent = (Collider collider) =>
    {

    };
    [SerializeField] public UnityEvent SpawnDemon;


    private void Awake()
    {
        instance = this;
        GeneralEvent += (Collider collider) =>
          {

              if (collider.tag == "MirrorTrigger")
              {
                  StartMirrorScene();
                  SpawnDemon.Invoke();
              }
          };

    }

    /// <summary>
    /// All individually occuring custom events, don't need a separate system.
    /// </summary>

    public void StartMirrorScene()
    {
        kidsRoomDoor.OpenDoor(2f);
        husband.transform.position = enterRoomStartPoint.position;
        husband.transform.DOMoveZ(transform.position.z - 3f, 4f);

    }



}
