using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class DoorHandler : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float angleWhenOpened, angleWhenClosed;
    [SerializeField] bool playerCanOpen = true;
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip doorOpen, doorClose, doorLocked;

    public Action<bool> doorOpened = (bool a) => { };
    public bool CanOpen { get { return playerCanOpen; } set { playerCanOpen = value; } }



    void Start()
    {

    }

    public void OpenDoor(float time, bool isManagerCall = false)
    {
        if (playerCanOpen || isManagerCall)
        {
            doorOpened.Invoke(playerCanOpen);
            door.transform.DOLocalRotate(Vector3.up * angleWhenOpened, time);
            audioSource.clip = doorOpen;
            audioSource.Play();
            playerCanOpen = false;

        }
    }

    public void CloseDoor(float time, bool playerCanOpenAgain = true)
    {
        door.transform.DOLocalRotate(Vector3.up * angleWhenClosed, time);
        playerCanOpen = playerCanOpenAgain;
        audioSource.clip = doorClose;
        audioSource.Play();
    }


    public void PlayDoorLocked()
    {
        audioSource.clip = doorLocked;
        audioSource.Play();
    }

    public void RattleDoor(float time)
    {
        door.transform.DOShakeRotation(time, 5f, 1, 10); //Rework
    }

}
