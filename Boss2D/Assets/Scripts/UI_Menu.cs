using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    GameManager gm;
    void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Iniciar()
    {
        gm.Reset();
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
