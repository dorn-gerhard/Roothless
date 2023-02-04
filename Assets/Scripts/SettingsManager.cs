using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public bool SoundIsOn { get; private set; }
    public bool MusicIsOn { get; private set; }

    [SerializeField] Button musicButton;
    [SerializeField] Button soundButton;

    private TextMeshProUGUI musicText;
    private TextMeshProUGUI soundText; 


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        musicText = musicButton.GetComponentInChildren<TextMeshProUGUI>();
        soundText = soundButton.GetComponentInChildren<TextMeshProUGUI>();

        SoundIsOn = true;
        MusicIsOn = true;

        UpdateMusicText();
        UpdateSoundText();
    }

    private void UpdateSoundText()
    {
        if (SoundIsOn)
            soundText.text = "Sound: On";
        else
            soundText.text = "Sound: Off";
    }


    private void UpdateMusicText()
    {
        if (MusicIsOn)
            musicText.text = "Music: On";
        else
            musicText.text = "Music: Off";
    }


    public void ToggleSound()
    {
        SoundIsOn = !SoundIsOn;
        UpdateSoundText();
    }

    public void ToggleMusic()
    {
        MusicIsOn = !MusicIsOn;
        UpdateMusicText();
    }
    
}