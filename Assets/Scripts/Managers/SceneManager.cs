using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public SceneDriver scenedriver;
    public System.Action<Collider> GeneralEvent = (Collider collider) =>
    {

    };
    public System.Action<string> GeneralInteractionEvents = (string event1) => { };


    public virtual void WhatIsBeingHighlighted(GameObject g)
    {

    }

}
