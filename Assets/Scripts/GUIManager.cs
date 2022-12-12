using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        enabled = false;
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        enabled = true;
    }
}
