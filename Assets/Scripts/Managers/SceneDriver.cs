using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDriver : MonoBehaviour
{
    public List<SceneManager> scenemanagers = new List<SceneManager>();
    public static SceneManager activeSceneManager;
    private int sceneindex = -1;
    private void Awake()
    {
        foreach (SceneManager scenemanager in scenemanagers)
        {
            scenemanager.enabled = false;
        }
        DontDestroyOnLoad(gameObject);
        switchScene();
    }
    public void switchScene()
    {
        activeSceneManager = scenemanagers[++sceneindex];
        if (sceneindex >= 1)
        {
            scenemanagers[sceneindex - 1].enabled = false;

        }
        activeSceneManager.enabled = true;
    }

}
