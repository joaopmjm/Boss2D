using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;
    public enum GameState {MENU, GAME, PAUSE, SHOP, ENDGAME};
    public GameState gameState {get; private set;}
    public int vidas;
    public int money;
    public int pontos;
    public int level;
    public float timeBetweenSpawns;
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }

    public bool SpendMoney(int gasto)
    {
        if(gasto <= money)
        {
            money -= gasto;
            return true;
        }
        return false;
    }

    public void LevelUp()
    {
        if(level >= 3)
        {
            ChangeState(GameManager.GameState.ENDGAME);
            return;
        }
        ChangeState(GameManager.GameState.SHOP);
        level++;
    }

    public void ChangeState(GameState nextState)
    {
        if(gameState == GameState.ENDGAME && nextState == GameState.GAME) Reset();
        if(gameState == GameState.PAUSE && nextState == GameState.MENU) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 100;
        money = 0;
        level = 1;
        pontos = 0;
    }
    private GameManager()
    {
        Reset();
        gameState = GameState.MENU;
    }

    private void HealCastle(int life, bool fullLife = false)
    {
        if(fullLife)
        {
            vidas = 100;
        }
        else
        {
            vidas += life;
            if(vidas > 100) vidas = 100; 
        }
    }
}
