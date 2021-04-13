using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] Button resume, exit;

    public void Paused()
    {
        exit.gameObject.SetActive(true);
        resume.gameObject.SetActive(true);
        Time.timeScale = 0;
        this.gameObject.SetActive(false);
    }
    public void Resume()
    {
        exit.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        Time.timeScale = 1;
        this.gameObject.SetActive(true);
        MusicPlayer.source.volume = 0.8f;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        MusicPlayer.source.volume = 1f;
    }
    
}
