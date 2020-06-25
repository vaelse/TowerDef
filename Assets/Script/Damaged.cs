using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damaged : MonoBehaviour
{
    public GameObject monsterHealthBar;
    TextMesh monsterTextMesh;
    public Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
       
    }
    private void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (monsterTextMesh.text.Length <= 0)
        {
            agent.Stop();
            anim.Play("Die");
            Destroy(gameObject, .8f);
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