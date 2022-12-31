using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public int playingScene;
    public int gameOverScene;
    public int mainMenuScene;
    public int succesful;
    public static ScenesManager scenesManager;

    void Start()
    {
        scenesManager = this;
    }
    public void GameOverScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(gameOverScene);
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    public void PlayingScene()
    {
        SceneManager.LoadScene(playingScene);
    }
    public void Succesful()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(succesful);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
