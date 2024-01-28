using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SC_SceneManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Camera startcam;
    [SerializeField]
    Camera playercam;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject focusStart;
    [SerializeField]
    GameObject focusGame;
    [SerializeField]
    GameObject fakePouic;
    [SerializeField]
    GameObject uiStartFolder;
    [SerializeField]
    GameObject uiCreditsFolder;
    [SerializeField]
    GameObject uiInGameFolder;

    private void Awake()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Cursor.visible = false;

        uiStartFolder.SetActive(false);
        uiInGameFolder.SetActive(true);

        startcam.GetComponent<Animator>().Play("A_SwitchCam");
        //start anime

    }

    public void SwitchCam()//animation event
    {
        //change pouic, activate player
        fakePouic.SetActive(false);
        player.SetActive(true);

        //switch cam
        playercam.gameObject.SetActive(true);
        canvas.worldCamera = playercam;
        startcam.gameObject.SetActive(false);

        //change dpf
        focusGame.SetActive(true);
        focusStart.SetActive(false);
        
    }

    public void PlayCredits()
    {
        uiStartFolder.SetActive(false);
        uiCreditsFolder.SetActive(true);
    }

    public void LeaveCredits()
    {
        uiCreditsFolder.SetActive(false);
        uiStartFolder.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
