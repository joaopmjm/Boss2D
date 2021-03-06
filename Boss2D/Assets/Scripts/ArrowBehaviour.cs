using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    GameManager gm;
    public AudioClip hurtSound;
    public AudioClip launchSound;
    private int dmg;
    Vector3 stageDimensions; 
    void Start()
    {
        gm = GameManager.GetInstance();
        dmg = gm.arrowDmg;
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        AudioManager.PlaySFX(launchSound);
    }
    bool isOut()
    {
        if(transform.position.x > stageDimensions.x | transform.position.x < -stageDimensions.x | transform.position.y > stageDimensions.y)
        {
            return true;
        }
        return false;
    }
    void Update()
    {
        if(isOut()) Destroy(gameObject);
        if(gm.gameState != GameManager.GameState.GAME) return;
        float angle = Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Zombie"))
        {
            col.gameObject.GetComponent<BaseEnemy>().takeDamage(dmg);
            AudioManager.PlaySFX(hurtSound);
            Destroy(gameObject);
        }
    }
}
