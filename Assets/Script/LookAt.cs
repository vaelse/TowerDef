using System.Collections.Generic;
using System.Linq;
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
        if (ListOfMonsters.Count > 0)
        {
            //if object at the top of the list is destroyed remove it from the list
            if (ListOfMonsters.FirstOrDefault() == null)
                Remove();
            else if (monsterTrigger == true)
            {
                //Turret focuses on the object that is on the top of the list
                transform.LookAt(ListOfMonsters.FirstOrDefault().transform);
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
            ListOfMonsters.Remove(other);
    }

    public void Remove()
    {
        ListOfMonsters.Remove(ListOfMonsters.FirstOrDefault());
    }

    private void Shoot()
    {
        if (fireCountdown <= 0)
        {
            var Bullet = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
            Bullet.GetComponent<TurretShooting>().target = ListOfMonsters.FirstOrDefault().transform;
            fireCountdown = fireRate;
        }
    }
}

