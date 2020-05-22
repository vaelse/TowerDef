﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPLoss : MonoBehaviour
{
    public GameObject healthBar;
    TextMesh CastleTextMesh;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Spawn.monsterCount--;
            TowerDamaged();
            Destroy(collision.gameObject);
        }
    }
    public void TowerDamaged()
    {
        CastleTextMesh = healthBar.GetComponent<TextMesh>();
        CastleTextMesh.text = CastleTextMesh.text.Remove(CastleTextMesh.text.Length - 1);
    }

}
