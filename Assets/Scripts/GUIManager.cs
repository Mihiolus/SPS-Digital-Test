using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Button damageBtn, speedBtn;
    public float damageIncrease = .25f, speedIncrease = .25f;

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
        damageBtn.interactable = false;
        speedBtn.interactable = false;
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

    public void IncreaseDamage()
    {
        Runner.Damage = Runner.Damage * (1f + damageIncrease);
    }

    public void IncreaseSpeed()
    {
        Runner.AttackInterval = Runner.AttackInterval * (1f - speedIncrease);
    }
}
