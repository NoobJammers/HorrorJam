using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{

    float mouseSensi;
    public float mouseSensitivity { set { mouseSensi = value; } get { return mouseSensi; } }
    [SerializeField] Transform playerBody;
    float xRotation = 0f, yRotation = 0f, zRotation = 0f, increamentValue = 0.007f, threshold = 0.7f;

    bool shouldTween = false, increament = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (shouldTween)
        {
            if (zRotation > threshold)
            {
                increament = false;
            }
            else if (zRotation < -threshold)
            {
                increament = true;
            }

            if (increament)
                zRotation += increamentValue;
            else
                zRotation -= increamentValue;
        }
        else
        {
            if (zRotation > 0.2f || zRotation < -0.2f)
            {
                if (zRotation > 0.2f)
                    zRotation -= increamentValue;
                else
                    zRotation += increamentValue;



            }
            else
                zRotation = 0f;

        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        playerBody.Rotate(Vector3.up * mouseX);
    }


    public void StartCameraTween()
    {
        shouldTween = true;
    }

    public void EndCameraTween()
    {
        shouldTween = false;
    }
}
