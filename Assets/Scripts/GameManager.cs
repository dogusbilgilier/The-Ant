using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnDeath += LoadEndingScene;
    }
    void OnDisable()
    {
        EventManager.OnDeath -= LoadEndingScene;
    }
   
    void LoadOpeningScene()
    {
        SceneManager.LoadScene(0);
    }
    void LoadEndingScene()
    {
        Invoke(nameof(LoadWithDelay), 7);
    }
    void LoadWithDelay()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
