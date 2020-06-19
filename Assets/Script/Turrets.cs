using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject towerPrefab;
    bool Istowerbuild = false;
    
    private void OnMouseDown()
    {
        if (Istowerbuild == false)
        {
            Istowerbuild = true;
            GameObject g = Instantiate(towerPrefab);
            g.transform.position = transform.position + new Vector3(0, 0.75f, 0);
        }
    }
}
