using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    GameManager gm;
    Text mensagem;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        mensagem.text = "Ainda não implementada, Soh vai gastar sua grana!";
    }

    public void ArrowDMG()
    {
        bool i = gm.SpendMoney(10);
    }

    public void FasterShots()
    {
        bool i = gm.SpendMoney(5);
    }

    public void Continuar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
