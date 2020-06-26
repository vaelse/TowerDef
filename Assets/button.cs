using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public Button destorybutton;
  
    void Update()
    {
        Vector3 buttonpos = Camera.main.WorldToScreenPoint(transform.position);
        destorybutton.transform.position = buttonpos + new Vector3(0, 80, 0);
    }

    public void onbutonclick()
    {
        Destroy(transform.parent.gameObject);
    }
}
