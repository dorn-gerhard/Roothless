using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Canvas startMenu;
    [SerializeField] Canvas settingsMenu;
    [SerializeField] Canvas levelSelectMenu;

    [SerializeField] Button musicButton;
    [SerializeField] Button soundButton;

    private TextMeshProUGUI musicText;
    private TextMeshProUGUI soundText;

    private void Awake()
    {
        musicText = musicButton.GetComponentInChildren<TextMeshProUGUI>();
        soundText = soundButton.GetComponentInChildren<TextMeshProUGUI>();

    }

    private void OnEnable()
    {
        SettingsManager.SoundSettingChanged += UpdateSoundText;
        SettingsManager.MusicSettingChanged += UpdateMusicText;
    }

    private void OnDisable()
    {
        SettingsManager.SoundSettingChanged -= UpdateSoundText;
        SettingsManager.MusicSettingChanged -= UpdateMusicText;
    }

    private void UpdateMusicText()
    {
        musicText.text = SettingsManager.Instance.GetMusicText();
    }

    private void UpdateSoundText()
    {
        soundText.text = SettingsManager.Instance.GetSoundText();
    }

    public void StartGame() 
    {
        StartCoroutine(StartGameCR());
    }

    public void GoToSettings() 
    {
        startMenu.enabled = false;
        settingsMenu.enabled = true;
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
        SceneManager.LoadScene("Nick's Scene");
    }


    private IEnumerator QuitGameCR()
    {
        yield return null;
        Application.Quit();
    }
}