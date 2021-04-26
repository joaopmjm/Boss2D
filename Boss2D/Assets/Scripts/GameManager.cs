using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;
    public enum GameState {MENU, GAME, PAUSE, SHOP, ENDGAME};
    public GameState gameState {get; private set;}
    public int money;
    public int pontos;
    public int level = 0;
    public float timeBetweenSpawns;
    public int enemysOnline;
    public int arrowDmg;
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

    public int getLife()
    {
        return GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().vida;
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
        if(level >= 2)
        {
            ChangeState(GameManager.GameState.ENDGAME);
            return;
        }
        level++;
        ChangeState(GameManager.GameState.SHOP);
    }

    public void ChangeState(GameState nextState)
    {
        if(gameState == GameState.ENDGAME && nextState == GameState.GAME) Reset();
        if(gameState == GameState.PAUSE && nextState == GameState.MENU) Reset();
        gameState = nextState;
        changeStateDelegate();
    }

    public void Reset()
    {
        GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().Reset();
        arrowDmg = 2;
        enemysOnline = 0;
        money = 0;
        level = 0;
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
            GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().Reset(); 
        }
        else
        {
            GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().heal(life);
        }
    }
}
