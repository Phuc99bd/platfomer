﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heaths : MonoBehaviour
{
    public Sprite[] hearths;

    public Player player;
    public Image heart;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        heart.sprite = hearths[player.ourHealth];
    }
}
