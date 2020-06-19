using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Monster;
     public static int monsterCount = 0;
    float spawnTime;
    float respawnDelay = 2f;

    public void Update()
    {
        if (monsterCount < 3)
            MonsterSpawn();      
    }

    public void MonsterSpawn()
    {
        //a small spawn delay for monsters
        if (spawnTime + respawnDelay > Time.unscaledTime)
            return;
        spawnTime = Time.unscaledTime;
        Instantiate(Monster, gameObject.transform);
        monsterCount++;
    }
}
