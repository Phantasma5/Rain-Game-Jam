﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static References instance;
    public static GameObject player;
    public static Rigidbody playerRigidbody;
    public static StatSystem playerStatSystem;
    private void Awake()
    {
        if(null != instance)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
        FindReferences();
    }
    private void FindReferences()
    {
        player = GameObject.FindWithTag("Player");
        if (null != player)
        {
            playerRigidbody = player.GetComponent<Rigidbody>();
            playerStatSystem = player.GetComponent<StatSystem>();
        }
    }
}
