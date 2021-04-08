using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyZombie : BaseEnemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        vida = 2;
        dmg = 2;
        speed = 3.0f;
        points = 2;
        gm = GameManager.GetInstance();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0.0f);
    }
}
