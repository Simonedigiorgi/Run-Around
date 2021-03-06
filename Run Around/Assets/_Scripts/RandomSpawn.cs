﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    private PlayerController pc;

    public GameObject[] obstacles;

    private float InstantiationTimer;

    private float spawnTime;
    public float maxTime;

    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;

    void Start () {
        pc = FindObjectOfType<PlayerController>();
        startPos = transform.position;
        //maxTime = 1;
    }
	
	void Update () {

        spawnTime = Random.Range(0.1f, maxTime);

        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;

        if (pc.isActive)
        {
            CreatePrefab();
        }
    }

    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform.position, Quaternion.identity);
            InstantiationTimer = spawnTime;
        }
    }
}
