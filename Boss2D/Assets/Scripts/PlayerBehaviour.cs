using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float shotTimeDeplay;
    GameManager gm;
    public GameObject arrow;
    float force;
    float forceLim = 15.0f;
    float lastShot = 0.0f;
    float shotDelay = 1.0f;
    float angle;
    bool keyIsDown = false;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Shoot()
    {
        GameObject flecha = Instantiate(arrow, transform.position, Quaternion.identity);
        if(angle >= 0)
        {
            flecha.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(Mathf.Cos(angle)*force),Mathf.Sin(angle)*force);
        }else
        {
            flecha.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(Mathf.Cos(360 - angle)*force),Mathf.Sin(angle)*force);
        }
    }

    float GetAngleBetweenBowAndMouse()
    {
        var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(angulo > 90){
            angulo -= 180;
        }else if(angulo < -90){
            angulo += 180;
        }
        return angulo;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) gm.ChangeState(GameManager.GameState.PAUSE);
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(keyIsDown)
        {
            if(force < forceLim)
            {
                force += 10.0f * (float) Time.deltaTime;
            } 
        }
        angle = GetAngleBetweenBowAndMouse();
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        if(Input.GetButtonDown("Fire1"))
        {
            keyIsDown = true;
        }
        if(Input.GetButtonUp("Fire1") && force > 0)
        {
            keyIsDown = false;
            if(Time.time - lastShot >= shotDelay)
            {
                Shoot();
                lastShot = Time.time;
            }
            force = 0;
        }
    }
}
