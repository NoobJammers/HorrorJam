using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float angleWhenOpened, angleWhenClosed;
    void Start()
    {

    }

    public void OpenDoor(float time)
    {
        door.transform.DOLocalRotate(Vector3.up * angleWhenOpened, time);
    }

    public void CloseDoor(float time)
    {
        door.transform.DOLocalRotate(Vector3.up * angleWhenClosed, time);

    }

    public void RattleDoor(float time)
    {

    }

}
