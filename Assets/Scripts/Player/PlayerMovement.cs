using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody rigidBody;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] float lookSpeed = 100f;
    [SerializeField] float movementSpeed = 12f;

    Vector3 move;
    private void Start()
    {
        mouseLook.mouseSensitivity = lookSpeed;
    }
    void Update()
    {

        if (Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Vertical") > 0.1f)
        {
            //Do cam tween
            mouseLook.StartCameraTween();
        }
        else
        {
            //End tween
            mouseLook.EndCameraTween();

        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        rigidBody.velocity = move.normalized * movementSpeed;
    }
}
