using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateBehaviour : MonoBehaviour
{
    public int vida;
    int vidaMax = 100;
    GameManager gm;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        vida = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(vida <= 0)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        img.fillAmount = (float)vida/(float)vidaMax;
    }

    public void Reset()
    {
        vida = vidaMax;
    }

    public int GetLife()
    {
        return vidaMax - vida;
    }

    public void heal(int heal)
    {
        vida += heal;
        if(vida > vidaMax) vida = vidaMax;
    }
    public void takeDamage(int dmg)
    {
        vida -= dmg;
    }
}
