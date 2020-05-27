using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject towerPrefab;

    //Instantiate a tower prefab on mouse click
    private void OnMouseUp()
    {
        GameObject g = Instantiate(towerPrefab);
        g.transform.position = transform.position + new Vector3(0, 0.75f, 0);
    }
}
