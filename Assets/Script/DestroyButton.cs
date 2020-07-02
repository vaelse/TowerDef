using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyButton : MonoBehaviour
{
    public Button destoryButton;

    void Update()
    {
        Vector3 buttonPosition = Camera.main.WorldToScreenPoint(transform.position);
        destoryButton.transform.position = buttonPosition + new Vector3(0, 40, 0);
    }

    public void Onbutonclick()
    {
        gameObject.transform.parent.transform.parent.GetComponent<Turrets>().Istowerbuild = false;
        Destroy(transform.parent.gameObject);
    }
}
