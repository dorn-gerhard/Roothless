using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayMusic() => audioSource.Play();

    public void PauseMusic() => audioSource.Pause();
}