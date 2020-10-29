using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject[] Monster;
    public Text timer;
    public static int aliveMonsterCount = 0;
    float respawnDelay = 1.5f;
    float countdown = 5f;
    float waveDelay = 5f;
    public int monstersOnWave = 1;
    int waveIndex = 1;

    public void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = waveDelay;
        }

        if (countdown > 0 && aliveMonsterCount <= 0)
        {
            countdown -= Time.deltaTime;
            timer.text = string.Format("{0:0}", countdown);
        }
    }

public void MonsterSpawn()
    {
        if (waveIndex < 3)
        {
            Instantiate(Monster[0], gameObject.transform);
            aliveMonsterCount++;
        }
        else if(waveIndex <= 5 && waveIndex >= 3)
        {
            respawnDelay = 1f;
            Instantiate(Monster[1], gameObject.transform);
            aliveMonsterCount++;
        }
        else if (waveIndex <= 7 && waveIndex >= 6 )
        {
            respawnDelay = 2.5f;
            Instantiate(Monster[2], gameObject.transform);
            aliveMonsterCount++;
        }
        else if (waveIndex >= 8)
        {
            respawnDelay = 2f;
            Instantiate(Monster[UnityEngine.Random.Range(0,Monster.Length)], gameObject.transform);
            aliveMonsterCount++;
        }
    }
  
   IEnumerator SpawnWave()
    {
        for (int i =0; i < monstersOnWave; i++)
        {
            MonsterSpawn();
            yield return new WaitForSeconds(respawnDelay);
        }
        waveIndex++;
        if (monstersOnWave < 6)
        {
            monstersOnWave++;
        }
    }
}
