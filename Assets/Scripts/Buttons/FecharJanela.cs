using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharJanela : MonoBehaviour
{
    public void Fechar(GameObject Janela)
    {
        Janela.SetActive(false);
    }
    public void Abrir(GameObject Janela)
    {
        Janela.SetActive(true);
    }
}
