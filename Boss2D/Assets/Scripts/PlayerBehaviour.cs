using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    GameManager gm;
    Vector2 dir;
    public GameObject arrow;
    float force = 0f;
    float forceLim = 1500f;
    public float forceDiff = 400f;
    float lastShot = 0.0f;
    public float shotDelay = 1.0f;
    bool keyIsDown = false;
    Animator animator;

    void Start()
    {
        gm = GameManager.GetInstance();
        animator = GetComponent<Animator>();
    }

    void Shoot()
    {
        GameObject flecha = Instantiate(arrow, transform.position, Quaternion.identity);

        flecha.gameObject.GetComponent<Rigidbody2D>().AddForce(dir.normalized * force);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) gm.ChangeState(GameManager.GameState.PAUSE);
        if(gm.gameState != GameManager.GameState.GAME) return;
        if(keyIsDown)
        {
            if(force < forceLim)
            {
                force += forceDiff * (float) Time.deltaTime;
                
            } 
        }
        else{
            animator.SetBool("Pulled", false);
        }
        GameObject.FindGameObjectsWithTag("ArrowStrenghtBar")[0].GetComponent<Image>().fillAmount = force/forceLim;
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        if (Input.GetButtonDown("Fire1"))
        {
            keyIsDown = true;
            animator.SetBool("Pulled", true);
        }
        if(Input.GetButtonUp("Fire1") && keyIsDown)
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