using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverScreen.SetActive(false);
    }

    private void GameStart()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        enabled = false;
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        enabled = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Single);
    }
}
