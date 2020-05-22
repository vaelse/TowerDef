using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshPath : MonoBehaviour
{
    void Start()
    {
        GameObject castle = GameObject.Find("Castle");
        if(castle)
        {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }
    }
}
