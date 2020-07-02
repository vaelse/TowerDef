using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Turrets : MonoBehaviour
{
    public GameObject towerPrefab;
    public bool Istowerbuild = false;
   
    private void OnMouseDown()
    {
        if (Istowerbuild == false && !EventSystem.current.IsPointerOverGameObject())
        {
            Istowerbuild = true;
            GameObject g = Instantiate(towerPrefab);
            g.transform.position = transform.position + new Vector3(0, 0.75f, 0);
            g.transform.parent = gameObject.transform;
        }
    }
}
