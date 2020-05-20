using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshPath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject castle = GameObject.Find("Castle");
        if(castle)
        {
            GetComponent<NavMeshAgent>().destination = castle.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
