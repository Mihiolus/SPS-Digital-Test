using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager
{
    public delegate void GameEvent();

    public static event GameEvent GameStart, GameOver, GoldChanged;

    public static void TriggerGameStart()
    {
        GameStart?.Invoke();
    }

    public static void TriggerGameOver()
    {
        GameOver?.Invoke();
    }

    public static void OnGoldChanged(){
        GoldChanged?.Invoke();
    }
}
