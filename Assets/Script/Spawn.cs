using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Monster;
     int monsterCount = 0;
    float spawnTime;
    float respawnDelay = 2f;
    public void Update()
    {
        Debug.Log(monsterCount);
        if (monsterCount < 5)
            spawn();      
    }

    public void spawn()
    {
        if (spawnTime + respawnDelay > Time.unscaledTime)
            return;
        spawnTime = Time.unscaledTime;
        Instantiate(Monster, gameObject.transform);
        monsterCount++;
    }
}
