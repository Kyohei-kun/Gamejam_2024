using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SceneManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Camera startcam;
    [SerializeField]
    Camera playercam;
    [SerializeField]
    GameObject uiStartFolder;
    [SerializeField]
    GameObject uiCreditsFolder;
    [SerializeField]
    GameObject uiInGameFolder;

    public void StartGame()
    {
        playercam.gameObject.SetActive(true);
        canvas.worldCamera = playercam;
        startcam.gameObject.SetActive(false);
        uiStartFolder.SetActive(false);
        uiInGameFolder.SetActive(true);
		Cursor.visible = true;
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
