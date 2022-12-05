using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    GameObject[] Buttons;

    void Start()
    {

    }

    public void FadeIn()
    {
        UpdateList();
        
    }

    void UpdateList()
    {
        Buttons = GameObject.FindGameObjectsWithTag("Button");
    }
}
