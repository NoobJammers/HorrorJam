using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene4Manager : MonoBehaviour
{

    static public Scene4Manager instance;
    [SerializeField] GameObject husband, wife, kid;
    [SerializeField] DoorHandler kidsRoomDoor;
    [SerializeField] Transform enterRoomStartPoint;

    private void Awake()
    {
        instance = this;
    }


    public void StartMirrorScene()
    {
        kidsRoomDoor.OpenDoor(2f);
        husband.transform.position = enterRoomStartPoint.position;
        husband.transform.DOMoveZ(transform.position.z - 3f, 4f);
    }

}
