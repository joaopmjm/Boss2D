using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    public void Continuar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
