using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseView;
    [SerializeField] private Canvas pauseSettingsView;
    [SerializeField] private Canvas backgroundCanvas;

    [SerializeField] Button soundButton;
    [SerializeField] Button musicButton;

    [SerializeField] TextMeshProUGUI soundText;
    [SerializeField] TextMeshProUGUI musicText;



    private bool pauseMenuIsActive = false;

    private void Awake()
    {
        soundButton.onClick.RemoveAllListeners();
        soundButton.onClick.AddListener(() => { SettingsManager.Instance.ToggleSound(); });

        musicButton.onClick.RemoveAllListeners();
        musicButton.onClick.AddListener(() => { SettingsManager.Instance.ToggleMusic(); });
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

    //bool pressedPause;
    public void OnPause(InputValue value)
    {
        TogglePauseMenu();
    }

    private void TogglePauseMenu()
    {
        Debug.Log("Pause menu is " + pauseMenuIsActive);
        if (pauseMenuIsActive)
            ClosePauseMenu();
        else
            OpenPauseMenu();
    }

    private void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        backgroundCanvas.enabled = true;
        pauseView.enabled = true;
        pauseSettingsView.enabled = false;
        pauseMenuIsActive = true;
    }

    private void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        backgroundCanvas.enabled = false;
        pauseView.enabled = false;
        pauseSettingsView.enabled = false;
        pauseMenuIsActive = false;
    }

    public void ResumeGame() => ClosePauseMenu();

    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void ShowSettings()
    {
        pauseView.enabled = false;
        pauseSettingsView.enabled = true;
    }

    public void BackToPauseMenu()
    {
        pauseView.enabled = true;
        pauseSettingsView.enabled = false;
    }

    public void QuitGame()
    {

    }
}