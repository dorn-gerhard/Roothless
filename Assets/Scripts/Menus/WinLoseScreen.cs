using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas loseCanvas;
    [SerializeField] Canvas backgroundCanvas;

    public void OpenWinScreen() 
    {
        winCanvas.enabled = true;
        backgroundCanvas.enabled = true;

    }

    public void OpenLoseScreen() 
    {
        loseCanvas.enabled = true;
        backgroundCanvas.enabled = true;
    }

    private void CloseWinLoseScreen()
    {
        loseCanvas.enabled = false;
        winCanvas.enabled = false;
        backgroundCanvas.enabled = false;
    }

    public void RetryLevel() 
    {
        CloseWinLoseScreen();
        StartCoroutine(RetryLevelCR());
    }

    public void GoBackToStart()
    {
        CloseWinLoseScreen();
        StartCoroutine(GoBackToStartCR());
    }

    private IEnumerator GoBackToStartCR()
    {
        CloseWinLoseScreen();
        yield return TransitionsManager.Instance.PlayOutro();
        SceneManager.LoadScene("Start Menu");
    }

    private IEnumerator RetryLevelCR()
    {
        yield return TransitionsManager.Instance.PlayOutro();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
