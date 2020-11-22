using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public int hearth = 100;
    public int exp = 200;
    public Player player;
    public Text brickExp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hearth <= 0)
        {
            player.upExp(exp);
            Destroy(gameObject);
        }
    }
    void Damage(int damage)
    {
        hearth -= damage;
    }
}
