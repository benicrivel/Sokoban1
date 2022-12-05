using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirCena : MonoBehaviour
{
    public void AbrirPropriaCena()
    {
        string name = SceneManager.GetActiveScene().name;
        GameObject.Find("Transição").GetComponent<Transicao>().IniciarTransicao(name);
    }

    public void AbrirProximoNivel()
    {
        string name = SceneManager.GetActiveScene().name;

        int a = int.Parse(name);
        a = a + 1;

        int amax = FileBasedPrefs.GetInt("Level Max");

        if (a > amax)
        {
            amax = a;
        }

        FileBasedPrefs.SetInt("Level Max", amax);

        if (!SteamManager.Initialized) { return; }

        GameObject.Find("Transição").GetComponent<Transicao>().IniciarTransicao(a.ToString());
    }

    public void AbrirScene(string SceneName)
    {
        GameObject.Find("Transição").GetComponent<Transicao>().IniciarTransicao(SceneName);

    }
    public void AbrirLevelMax()
    {
        int amax = FileBasedPrefs.GetInt("Level Max");
        GameObject.Find("Transição").GetComponent<Transicao>().IniciarTransicao(amax.ToString());
    }

    public void AbrirLevel()
    {
        int a = FileBasedPrefs.GetInt("Level");
        GameObject.Find("Transição").GetComponent<Transicao>().IniciarTransicao(a.ToString());
    }
}
