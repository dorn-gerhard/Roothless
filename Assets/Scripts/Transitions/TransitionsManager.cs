using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsManager : MonoBehaviour
{
    public static TransitionsManager Instance { get; private set; }

    [SerializeField] float transitionDuration;
    [SerializeField] Canvas transitionsCanvas;
    [SerializeField] Material mat;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            transitionsCanvas.worldCamera = Camera.main;
            SetProgress(1);
            StartCoroutine(SplashCoroutine());
        }
    }

    public IEnumerator PlayIntro()
    {
        SetProgress(1);
        float passedTime = 0;
        while (passedTime < transitionDuration)
        {
            passedTime += Time.deltaTime;
            SetProgress(Mathf.SmoothStep(1, 0, passedTime / transitionDuration));
            yield return null;
        }
        SetProgress(0);
        transitionsCanvas.enabled = false;
        yield return null;
    }


    public IEnumerator PlayOutro()
    {
        SetProgress(0);
        transitionsCanvas.enabled = true;
        float passedTime = 0;
        while (passedTime < transitionDuration)
        {
            passedTime += Time.deltaTime;
            SetProgress(Mathf.SmoothStep(0, 1, passedTime / transitionDuration));
            yield return null;
        }
        SetProgress(1);
        yield return null;
    }

    private void SetProgress(float progress) => mat.SetFloat("_Cutoff", progress);

    private IEnumerator SplashCoroutine()
    {
        yield return PlayIntro();
        yield return new WaitForSeconds(1.5f);
        yield return PlayOutro();
        SceneManager.LoadScene("Start Menu");
    }
}
