using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] AudioSource buttonSoundSource;
    [SerializeField] AudioClip highlightSound;
    [SerializeField] AudioClip clickSound;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayClickSound();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHighlightSound();
    }


    private void PlayHighlightSound()
    {
        if (SettingsManager.Instance.SoundIsOn)
        {
            Debug.Log("Playing Highlight Sound");
            buttonSoundSource.clip = highlightSound;
            buttonSoundSource.Play();
        }
    }

    private void PlayClickSound()
    {
        if (SettingsManager.Instance.SoundIsOn)
        {
            Debug.LogWarning("Playing CLICK Sound");
            buttonSoundSource.clip = clickSound;
            buttonSoundSource.Play();
        }
    }
}