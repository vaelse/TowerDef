using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    public GameObject monsterHealthBar;
    TextMesh monsterTextMesh;

    private void Update()
    {
        if(monsterTextMesh.text.Length <= 0)
        {
            Destroy(gameObject);
            Spawn.monsterCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            MonsterDamaged();
        }
    }

    public void MonsterDamaged()
    {
        //remove one character form TextMesh
        monsterTextMesh = monsterHealthBar.GetComponent<TextMesh>();
        monsterTextMesh.text = monsterTextMesh.text.Remove(monsterTextMesh.text.Length - 1);
    }

}