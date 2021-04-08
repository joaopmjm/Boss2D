using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{    
    public int vida;
    public int dmg;
    public float speed;
    public int points;
    public GameManager gm;
    // Start is called before the first frame update
    public virtual void Start()
    {
    }

    public void takeDamage(int damageTaken)
    {
        vida -= damageTaken;
    }
    // Update is called once per frame
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(vida <= 0){
            Destroy(gameObject);
            gm.pontos += points;
            gm.money += points;
        } 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Tower"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
        }
    }
}
