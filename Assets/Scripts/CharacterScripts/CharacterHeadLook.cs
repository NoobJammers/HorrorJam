using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeadLook : MonoBehaviour
{
    public GameObject NeckBone;
    public bool screweduplocaltransform;
    private bool keeplooking;
    private Vector3 originaldirection;
    private void Start()
    {
        originaldirection = transform.forward;
    }
    public void lookAt(Transform t)
    {
        if (!screweduplocaltransform)
            NeckBone.transform.rotation = Quaternion.LookRotation((Camera.main.transform.position - NeckBone.transform.position).normalized, Vector3.up) * Quaternion.Euler(-90, 0, 0) * Quaternion.Euler(0, 90, 0);
        else
        {
            NeckBone.transform.rotation = Quaternion.LookRotation((Camera.main.transform.position - NeckBone.transform.position).normalized, Vector3.up) * Quaternion.Euler(30, 0, 0);
        }
    }

    private void Update()
    {
        if (keeplooking)
        {
            lookAt(null);
        }
    }


    public void startlookingatplayer()
    {
        keeplooking = true;

    }

    public void stoplookingatplayer()
    {

        keeplooking = false;
        transform.forward = originaldirection;
    }
}
