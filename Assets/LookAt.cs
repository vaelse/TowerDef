using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    bool monsterTrigger = false;
    GameObject monster;
    public List<Collider> ListOfMonsters = new List<Collider>();

    private void Update()
    {
        if (ListOfMonsters.Count > 0)
        {
            //if object at the top of the list is destroyed remove it from the list
            if (ListOfMonsters[0] == null)
            {
                ListOfMonsters.Remove(ListOfMonsters[0]);
            }
            else if (monster != null && monsterTrigger == true)
            {
                //Turrets focuses on the object that is on the top of the list
                transform.LookAt(ListOfMonsters[0].transform);
            }
            else
            {
                monster = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            monsterTrigger = true;
            ListOfMonsters.Add(other);
            monster = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (ListOfMonsters.Contains(other))
        {
            ListOfMonsters.Remove(other);
        }
    }
}

