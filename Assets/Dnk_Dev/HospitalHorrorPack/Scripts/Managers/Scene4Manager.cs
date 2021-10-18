using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
public class Scene4Manager : MonoBehaviour
{

    static public Scene4Manager instance;
    [SerializeField]
    GameObject husband, wife, kid;
    [SerializeField] DoorHandler kidsRoomDoor;
    [SerializeField] Transform enterRoomStartPoint;
    [SerializeField] Transform kidbed;

    public System.Action<Collider> GeneralEvent = (Collider collider) =>
    {

    };
    [SerializeField] public UnityEvent SpawnDemon;
    [SerializeField] public UnityEvent<Vector3, Vector3> MoveManToPosition;

    private void Awake()
    {
        instance = this;
        GeneralEvent += (Collider collider) =>
          {

              if (collider.tag == "MirrorTrigger")
              {
                  Destroy(collider.gameObject);
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
        MoveManToPosition.Invoke(enterRoomStartPoint.position, kidbed.position);

    }



}
