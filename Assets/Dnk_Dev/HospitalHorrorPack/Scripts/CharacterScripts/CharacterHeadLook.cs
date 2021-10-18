using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeadLook : MonoBehaviour
{
    public GameObject NeckBone;

    private void Start()
    {
        /*     NeckBone.transform.up = (NeckBone.transform.position - Camera.main.transform.position).normalized;*/
    }
    public void lookAt(Transform t)
    {
        /*        NeckBone.transform.LookAt(t);*/
    }
}
