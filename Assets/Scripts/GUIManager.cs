using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GUIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Button damageBtn, speedBtn;
    public float damageIncrease = .25f, speedIncrease = .25f;
    public int cost = 20, costIncrease = 5;
    private int damageCost, speedCost;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        GameEventManager.GoldChanged += OnGoldChanged;
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        damageBtn.interactable = false;
        speedBtn.interactable = false;
        damageCost = cost;
        speedCost = cost;
    }

    private void OnGoldChanged()
    {
        damageBtn.interactable = Runner.Gold >= damageCost;
        speedBtn.interactable = Runner.Gold >= speedCost;
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
        GameEventManager.GameOver -= GameOver;
        GameEventManager.GoldChanged -= OnGoldChanged;
    }

    public void IncreaseDamage()
    {
        Runner.Damage = Runner.Damage * (1f + damageIncrease);
        Runner.Gold -= damageCost;
        damageCost += costIncrease;
    }

    public void IncreaseSpeed()
    {
        Runner.AttackInterval = Runner.AttackInterval * (1f - speedIncrease);
        Runner.Gold -= speedCost;
        speedCost += costIncrease;
    }
}
