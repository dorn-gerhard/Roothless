using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public bool SoundIsOn { get; private set; }
    public bool MusicIsOn { get; private set; }

    public delegate void SettingChanged();
    public static SettingChanged SoundSettingChanged;
    public static SettingChanged MusicSettingChanged;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        SoundIsOn = true;
        MusicIsOn = true;

        SoundSettingChanged?.Invoke();
        MusicSettingChanged?.Invoke();
    }

    public string GetSoundText()
    {
        if (SoundIsOn)
            return "Sound: On";
        else
            return "Sound: Off";
    }


    public string GetMusicText()
    {
        if (MusicIsOn)
            return "Music: On";
        else
            return "Music: Off";
    }


    public void ToggleSound()
    {
        SoundIsOn = !SoundIsOn;
        SoundSettingChanged?.Invoke();
        ResetButtonColor();
    }

    public void ToggleMusic()
    {
        MusicIsOn = !MusicIsOn;
        if (MusicIsOn)
            AudioManager.Instance.PlayMusic();
        else
            AudioManager.Instance.PauseMusic();
        MusicSettingChanged?.Invoke();
        ResetButtonColor();
    }



    private void ResetButtonColor()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

}