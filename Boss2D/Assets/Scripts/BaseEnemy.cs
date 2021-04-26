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
    bool reachedTarget = false;
    public AudioClip towerHurtSound;
    float damageDelay = 1f;
    float lastDmgDealt = 0.0f;
    public Animator animator;
    public virtual void Start()
    {
    }

    public void takeDamage(int damageTaken)
    {
        vida -= damageTaken;
    }
    void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(vida <= 0){
            Destroy(gameObject);
            gm.pontos += points;
            gm.money += points;
            gm.enemysOnline--;
        }
        if(reachedTarget && (Time.time - lastDmgDealt > damageDelay))
        {
            AudioManager.PlaySFX(towerHurtSound);
            GameObject.FindGameObjectsWithTag("Tower")[0].GetComponent<GateBehaviour>().takeDamage(dmg);
            lastDmgDealt = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Tower"))
        {
            animator.SetBool("ReachedTower", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            if(col.gameObject.CompareTag("Tower"))
            {
                lastDmgDealt = Time.time;
                reachedTarget = true;
            }
        }
    }
}
