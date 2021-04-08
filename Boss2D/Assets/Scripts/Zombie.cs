using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseEnemy
{
    // Start is called before the first frame update
    public override void Start()
    {
        vida = 4;
        dmg = 5;
        speed = 1.5f;
        points = 1;
        gm = GameManager.GetInstance();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0.0f);
    }
}
