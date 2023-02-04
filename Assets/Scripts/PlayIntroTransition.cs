using UnityEngine;

public class PlayIntroTransition : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(TransitionsManager.Instance.PlayIntro());
    }
}