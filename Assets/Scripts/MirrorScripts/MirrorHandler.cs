using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandler : MonoBehaviour
{
    [SerializeField] Transform PlayerCamera;
    [SerializeField] Transform mirrorCamera;


    void Start()
    {

    }

    void Update()
    {
        CalculateRotation();
    }

    void CalculateRotation()
    {
        Vector3 dir = (PlayerCamera.position - transform.position).normalized;
        dir.y = 0f;
        Quaternion rot = Quaternion.LookRotation(dir);
        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;

        if (rot.eulerAngles.y > 45f && rot.eulerAngles.y < 180f)
            rot.eulerAngles = new Vector3(rot.eulerAngles.x, 45f, rot.eulerAngles.z);
        else if (rot.eulerAngles.y < 315f && rot.eulerAngles.y > 180f)
            rot.eulerAngles = new Vector3(rot.eulerAngles.x, -45f, rot.eulerAngles.z);

        mirrorCamera.localRotation = rot;
    }
}
