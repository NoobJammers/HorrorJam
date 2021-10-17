using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "MirrorTrigger")
        {
            Destroy(other.gameObject);
            Scene4Manager.instance.StartMirrorScene();
        }
    }
}
