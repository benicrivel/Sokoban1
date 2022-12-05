using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // required when using UI elements in scripts
using UnityEngine.EventSystems;// Required when using Event data.

public class SelecionarBT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selecionar(Button selectButton)
    {
        selectButton.Select();
    }
}
