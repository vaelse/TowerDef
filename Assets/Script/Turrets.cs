using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Turrets : MonoBehaviour
{
    public GameObject towerPrefab;
    public bool Istowerbuild = false;
    GoldManager goldManager;

    private void Start()
    {
        goldManager = GameObject.Find("Tower Cubes").GetComponent<GoldManager>();
    }

    private void OnMouseDown()
    {
        if (int.Parse(goldManager.goldAmount.text) < 5)
        {
            goldManager.nogoldtext();
            return;
        }
        else if (Istowerbuild == false && !EventSystem.current.IsPointerOverGameObject())
        {
            BuildTowerButton();
        }
    }

    private void OnMouseOver()
    {
        if(Istowerbuild == false)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void BuildTowerButton()
    {
        Istowerbuild = true;
        GameObject g = Instantiate(towerPrefab);
        g.transform.position = transform.position + new Vector3(0, 0.75f, 0);
        g.transform.parent = gameObject.transform;
        goldManager.Turretcost(5);
    }
}
