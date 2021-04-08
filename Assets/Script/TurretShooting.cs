using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        if (target != null)
        {
            var direction = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = direction.normalized * 15f;
        }
        else
            Destroy(gameObject);
    }
}
