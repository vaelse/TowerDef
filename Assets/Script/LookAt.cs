using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    bool monsterTrigger = false;
    public GameObject bulletPrefab;
    public GameObject shootPoint;
    float fireCountdown = 0f;
    float fireRate = 1f;
    public List<Collider> ListOfMonsters = new List<Collider>();

    private void Update()
    {
        fireCountdown -= Time.deltaTime;
        var Monster = GameObject.FindGameObjectWithTag("Monster");
        Damaged MonsterHealth = Monster.GetComponent<Damaged>();

        if (ListOfMonsters.Count > 0)
        {
            //if object at the top of the list is destroyed remove it from the list
            if (MonsterHealth.monsterTextMesh.text.Length == 0)
            {
                ListOfMonsters.Remove(ListOfMonsters[0]);
            }
            else if (monsterTrigger == true)
            {
                //Turret focuses on the object that is on the top of the list
                transform.LookAt(ListOfMonsters[0].transform);
                Shooting();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            monsterTrigger = true;
            ListOfMonsters.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ListOfMonsters.Contains(other))
        {
            ListOfMonsters.Remove(other);
        }
    }

    private void Shooting()
    {
        if (fireCountdown <= 0)
        {
            GameObject Bull = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            Bull.GetComponent<TurretShooting>().target = ListOfMonsters[0].transform;
            fireCountdown = fireRate;
        }
    }
    
}

