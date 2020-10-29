using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
        if (ListOfMonsters.Count > 0)
        {
            //if object at the top of the list is destroyed remove it from the list
            if ( ListOfMonsters[0] == null)
            {
                remove();
            }
            else if (monsterTrigger == true)
            {
                //Turret focuses on the object that is on the top of the list
                transform.LookAt(ListOfMonsters[0].transform);
                Shoot();
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

    public void remove()
    {
        ListOfMonsters.Remove(ListOfMonsters[0]);
    }

    private void Shoot()
    {
        if (fireCountdown <= 0)
        {
            GameObject Bullet = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            Bullet.GetComponent<TurretShooting>().target = ListOfMonsters[0].transform;
            fireCountdown = fireRate;
        }
    }
}

