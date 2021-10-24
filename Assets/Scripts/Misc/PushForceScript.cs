using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForceScript : MonoBehaviour
{   
    public void push(Vector3 dir, float magnitude, Vector3 position)
    {
        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(dir * magnitude, position, ForceMode.Impulse);
      
    }

  
}
