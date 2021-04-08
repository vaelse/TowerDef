using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showbutton : MonoBehaviour
{
    public GameObject destroyButton;
    bool isButtonShown = false;

    private void OnMouseDown()
    {
        if (!isButtonShown)
        {
            destroyButton.SetActive(true);
            isButtonShown = true;
        }
        else
        {
            destroyButton.SetActive(false);
            isButtonShown = false;
        }
    }
}
