using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damaged : MonoBehaviour
{
    public GameObject monsterHealthBar;
    public TextMesh monsterTextMesh;
    public Animator anim;

    private void Start()
    {
        monsterTextMesh = monsterHealthBar.GetComponent<TextMesh>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MonsterDeath();
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
        if(monsterTextMesh.text.Length > 0)
            monsterTextMesh.text = monsterTextMesh.text.Remove(monsterTextMesh.text.Length - 1);
    }

    public void MonsterDeath()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (monsterTextMesh.text.Length <= 0)
        {
            agent.isStopped = true;
            anim.Play("Die");
            Destroy(gameObject, .5f);
            if (Spawn.monsterCount > 0)
            {
                Spawn.monsterCount--;
            }
        }
    }
}