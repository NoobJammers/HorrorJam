using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeadLook : MonoBehaviour
{
    public GameObject NeckBone;

    private void Start()
    {
        NeckBone.transform.LookAt(Camera.main.transform);
    }
    public void lookAt(Transform t)
    {
        NeckBone.transform.LookAt(t);
    }
}
