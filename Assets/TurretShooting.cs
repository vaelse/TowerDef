using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public Transform target;
    float speed = 20f;

    private void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        GetComponent<Rigidbody>().velocity = dir.normalized * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
}
