using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshPath : MonoBehaviour
{
    public float movementSpeed;
    void Start()
    {
        var castle = GameObject.Find("Castle");
        if (castle)
        {
            GetComponent<NavMeshAgent>().speed = movementSpeed;
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }
    }
}
