using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Rigidbody rigidBody;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] float lookSpeed = 200f;
    [SerializeField] float movementSpeed = 4f;

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
    private void OnTriggerEnter(Collider other)
    {
        SceneDriver.activeSceneManager.GeneralEvent.Invoke(other);

    }
}
