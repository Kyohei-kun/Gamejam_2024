using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_StartCamAnimEvent : MonoBehaviour
{
    [SerializeField] SC_SceneManager sceneManager;


    public void animEvent()
    {
        sceneManager.SwitchCam();
    }
}
