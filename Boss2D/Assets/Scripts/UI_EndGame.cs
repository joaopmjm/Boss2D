using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
    public Text message;
    GameManager gm;
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            Destroy(item);
        }
        if(gm.getLife() > 0){
            message.text = $"You Win!! Score: {gm.pontos}";
        }
        else
        {
            message.text = $"You Lost!! Score: {gm.pontos}";
        }
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
