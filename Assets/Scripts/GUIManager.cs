using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public TMP_Text gameOverText, instructionsText, runnerText;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverText.enabled = false;
    }

    private void GameStart()
    {
        gameOverText.enabled = false;
        instructionsText.enabled = false;
        runnerText.enabled = false;
        enabled = false;
    }

    private void GameOver()
    {
        gameOverText.enabled = true;
        instructionsText.enabled = true;
        enabled = true;
    }
}
