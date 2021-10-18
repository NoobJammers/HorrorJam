using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeadLook : MonoBehaviour
{
    public GameObject NeckBone;

    private void Start()
    {

    }
    public void lookAt(Transform t)
    {
        NeckBone.transform.rotation = Quaternion.LookRotation((Camera.main.transform.position - NeckBone.transform.position).normalized, Vector3.up) * Quaternion.Euler(-90, 0, 0) * Quaternion.Euler(0, 90, 0);

    }
}
