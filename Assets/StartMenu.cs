using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Canvas startMenu;
    [SerializeField] Canvas settingsMenu;
    [SerializeField] Canvas levelSelectMenu;

    public void StartGame() 
    {
        StartCoroutine(StartGameCR());
    }

    public void GoToSettings() 
    {
        startMenu.enabled = false;
        settingsMenu.enabled = true;
        Debug.Log(settingsMenu.isActiveAndEnabled);
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameCR());
    }

    public void CloseSettingsMenu() 
    {
        startMenu.enabled = true;
        settingsMenu.enabled = false;

    }

    public void CloseLevelSelector() 
    {
        startMenu.enabled = true;
        levelSelectMenu.enabled = false;
    }

    private IEnumerator StartGameCR()
    {
        yield return null;
        // open scene selection
        startMenu.enabled = false;
        levelSelectMenu.enabled = true;
    }


    private IEnumerator QuitGameCR()
    {
        yield return null;
        Application.Quit();
    }
}