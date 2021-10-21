using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<SceneManager> scenemanagers = new List<SceneManager>();
    public static SceneManager activeSceneManager;
    private int sceneindex = 0;
    public System.Action<Collider> GeneralEvent = (Collider collider) =>
    {

    };
    public System.Action<string> GeneralInteractionEvents = (string event1) => { };
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        switchScene();
    }
    public void switchScene()
    {
        activeSceneManager = scenemanagers[sceneindex++];
    }

    public virtual void WhatIsBeingHighlighted(GameObject g)
    {

    }

}
