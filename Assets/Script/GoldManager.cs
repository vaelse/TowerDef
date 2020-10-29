using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text goldAmount;
    public GameObject noGoldText;

    public void Turretcost(int buildcost)
    {
        goldAmount.text = (int.Parse(goldAmount.text) - buildcost).ToString();
    }

    public void Monsterdeathgold(int killgold)
    {
        goldAmount.text = (int.Parse(goldAmount.text) + killgold).ToString();
    }

    public void nogoldtext()
    {
        noGoldText.SetActive(true);
        Invoke("deactiveate", 3f);
    }
    public void deactiveate()
    {
        noGoldText.SetActive(false);
    }
}
