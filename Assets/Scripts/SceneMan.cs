using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScene");
        MusicPlayer.source.volume = 0.8f;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
