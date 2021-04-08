using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie : BaseEnemy
{
    public override void Start()
    {
        vida = 10;
        dmg = 10;
        speed = 0.5f;
        points = 3;
        gm = GameManager.GetInstance();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0.0f);
    }
}
