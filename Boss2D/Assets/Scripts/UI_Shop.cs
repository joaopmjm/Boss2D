using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    GameManager gm;
    Text healText;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        healText = GameObject.FindGameObjectsWithTag("HealButtonText")[0].GetComponent<Text>();
        healText.text = $"Curar castelo ${GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().GetLife()}";
    }

    public void ArrowDMG()
    {
        gm.arrowDmg += 1;
        bool i = gm.SpendMoney(10);
    }

    public void FasterShots()
    {
        if(GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerBehaviour>().shotDelay <= 0.2f)
        {
            return;
        }
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerBehaviour>().shotDelay -= 0.2f;
        bool i = gm.SpendMoney(5);
    }

    public void ChargeFaster()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerBehaviour>().forceDiff += 200f;
        bool i = gm.SpendMoney(5);
    }

    public void HealCastle()
    {
        int a = GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().GetLife();
        GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().heal(a);
        bool i = gm.SpendMoney(a);
    }

    public void Continuar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
