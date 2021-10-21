using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float angleWhenOpened, angleWhenClosed;
    bool playerCanOpen = true;
    public bool CanOpen { get { return playerCanOpen; } set { playerCanOpen = value; } }



    void Start()
    {

    }

    public void OpenDoor(float time, bool isManagerCall = false)
    {
        if (playerCanOpen || isManagerCall)
        {
            door.transform.DOLocalRotate(Vector3.up * angleWhenOpened, time);
            playerCanOpen = false;
        }
    }

    public void CloseDoor(float time, bool playerCanOpenAgain = true)
    {
        door.transform.DOLocalRotate(Vector3.up * angleWhenClosed, time);
        playerCanOpen = playerCanOpenAgain;
    }

    public void RattleDoor(float time)
    {
        door.transform.DOShakeRotation(time, 5f, 1, 10);
    }

}
